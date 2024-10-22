using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Forms;


public class FormsService(
    IPermissionsRepository permissionsRepository,
    IFormBUgUnitsRepository formBUgUnitsRepository,
    IFormBGuestUnitsRepository formBGuestUnitsRepository,
    IGuestUnitsRepository guestUnitsRepository,
    ICrewMembersRepository crewMembersRepository,
    IFormBShortResearchEquipmentsRepository formBShortResearchEquipmentsRepository,
    IResearchEquipmentsRepository researchEquipmentsRepository,
    IFormBLongResearchEquipmentsRepository formBLongResearchEquipmentsRepository,
    IFormBPortsRepository formBPortsRepository,
    IPortsRepository portsRepository,
    ICruiseDaysDetailsRepository cruiseDaysDetailsRepository,
    IFormBResearchEquipmentsRepository formBResearchEquipmentsRepository,
    IFormsBRepository formsBRepository,
    IUnitOfWork unitOfWork)
    : IFormsService
{
    public async Task DeleteFormB(FormB formB, CancellationToken cancellationToken)
    {
        await DeletePermissions(formB, cancellationToken);
        DeleteFormBUgUnits(formB);
        await DeleteFormBGuestUnits(formB, cancellationToken);
        await DeleteCrewMembers(formB, cancellationToken);
        await DeleteFormBShortResearchEquipments(formB, cancellationToken);
        await DeleteFormBLongResearchEquipments(formB, cancellationToken);
        await DeletePorts(formB, cancellationToken);
        await DeleteCruiseDaysDetails(formB, cancellationToken);
        await DeleteFormBResearchEquipments(formB, cancellationToken);
        RemoveShipEquipments(formB);
        
        formsBRepository.Delete(formB);
        await unitOfWork.Complete(cancellationToken);
    }


    private async Task DeletePermissions(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var permission in formB.Permissions)
        {
            if (await permissionsRepository.CountFormsA(permission, cancellationToken) == 0 &&
                await permissionsRepository.CountFormsB(permission, cancellationToken) == 1 && // The one to be deleted
                await permissionsRepository.CountFormsC(permission, cancellationToken) == 0)
            {
                permissionsRepository.Delete(permission);
            }
        }
        
        formB.Permissions.Clear();
    }
    
    private void DeleteFormBUgUnits(FormB formB)
    {
        foreach (var formBUgUnit in formB.FormBUgUnits)
        {
            formBUgUnitsRepository.Delete(formBUgUnit);
        }
    }

    private async Task DeleteFormBGuestUnits(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var formBGuestUnit in formB.FormBGuestUnits)
        {
            var guestUnit = formBGuestUnit.GuestUnit;
            formBGuestUnitsRepository.Delete(formBGuestUnit);
            
            if (await guestUnitsRepository.CountFormAGuestUnits(guestUnit, cancellationToken) == 0 &&
                await guestUnitsRepository.CountUniqueFormsB(guestUnit, cancellationToken) == 1) // The one to be deleted
            {
                guestUnitsRepository.Delete(guestUnit);
            }
        }
    }

    private async Task DeleteCrewMembers(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var crewMember in formB.CrewMembers)
        {
            if (await crewMembersRepository.CountUniqueFormsB(crewMember, cancellationToken) == 1) // The one to be deleted
                crewMembersRepository.Delete(crewMember);
        }
        
        formB.CrewMembers.Clear();
    }

    private async Task DeleteFormBShortResearchEquipments(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var formBShortResearchEquipment in formB.FormBShortResearchEquipments)
        {
            var researchEquipment = formBShortResearchEquipment.ResearchEquipment;
            formBShortResearchEquipmentsRepository.Delete(formBShortResearchEquipment);

            if (await researchEquipmentsRepository.CountFormCAssociations(researchEquipment, cancellationToken) == 0 && 
                await researchEquipmentsRepository.CountUniqueFormsB(researchEquipment, cancellationToken) == 1) // The one to be deleted
            {
                researchEquipmentsRepository.Delete(researchEquipment);
            }
        }
    }
    
    private async Task DeleteFormBLongResearchEquipments(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var formBLongResearchEquipment in formB.FormBLongResearchEquipments)
        {
            var researchEquipment = formBLongResearchEquipment.ResearchEquipment;
            formBLongResearchEquipmentsRepository.Delete(formBLongResearchEquipment);

            if (await researchEquipmentsRepository.CountFormCAssociations(researchEquipment, cancellationToken) == 0 && 
                await researchEquipmentsRepository.CountUniqueFormsB(researchEquipment, cancellationToken) == 1) // The one to be deleted
            {
                researchEquipmentsRepository.Delete(researchEquipment);
            }
        }
    }

    private async Task DeletePorts(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var formBPort in formB.FormBPorts)
        {
            var port = formBPort.Port;
            formBPortsRepository.Delete(formBPort);

            if (await portsRepository.CountFormCPorts(port, cancellationToken) == 0 && 
                await portsRepository.CountUniqueFormsB(port, cancellationToken) == 1) // The one to be deleted
            {
                portsRepository.Delete(port);
            }
        }
    }

    private async Task DeleteCruiseDaysDetails(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var cruiseDayDetails in formB.CruiseDaysDetails)
        {
            if (await cruiseDaysDetailsRepository.CountUniqueFormsC(cruiseDayDetails, cancellationToken) == 0 &&
                await cruiseDaysDetailsRepository.CountUniqueFormsB(cruiseDayDetails, cancellationToken) == 1) // The one to be deleted
            {
                cruiseDaysDetailsRepository.Delete(cruiseDayDetails);
            }
        }
        
        formB.CruiseDaysDetails.Clear();
    }
    
    private async Task DeleteFormBResearchEquipments(FormB formB, CancellationToken cancellationToken)
    {
        foreach (var formBResearchEquipment in formB.FormBResearchEquipments)
        {
            var researchEquipment = formBResearchEquipment.ResearchEquipment;
            formBResearchEquipmentsRepository.Delete(formBResearchEquipment);

            if (await researchEquipmentsRepository.CountFormCAssociations(researchEquipment, cancellationToken) == 0 &&
                await researchEquipmentsRepository.CountUniqueFormsB(researchEquipment, cancellationToken) == 1) // The one to be deleted
            {
                researchEquipmentsRepository.Delete(researchEquipment);
            }
        }
    }
    
    private static void RemoveShipEquipments(FormB formB)
    {
        formB.ShipEquipments.Clear();
    }
}