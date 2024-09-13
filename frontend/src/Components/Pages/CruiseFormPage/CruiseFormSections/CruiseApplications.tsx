import CruiseApplicationsList from "../../CruiseApplicationsPage/CruiseApplicationsList";
import {CruiseApplication} from "../../CruiseApplicationsPage/CruiseApplicationsPage";
import {Dispatch, SetStateAction, useContext} from "react";
import {FormContext} from "../../FormPage/Wrappers/FormTemplate";

type Props = {
    cruiseApplications: CruiseApplication[],
    setCruiseApplications: (applications: CruiseApplication[]) => void,
    addingMode: boolean,
    setAddingMode: Dispatch<SetStateAction<boolean>>
}


export default function CruiseApplications(props: Props) {
    const formContext = useContext(FormContext)
    const updateApplications = (applications: CruiseApplication[], disableAddingMode?: boolean = true) => {
        props.setCruiseApplications(applications)
        formContext!.setValue(
            "cruiseApplicationsIds",
            applications.map(app => app.id)
        )

        if (props.addingMode && disableAddingMode)
            props.setAddingMode(false)
    }

    return (
        <div className="p-2 w-100">
            <CruiseApplicationsList
                boundCruiseApplications={props.cruiseApplications}
                setBoundCruiseApplications={updateApplications}
                deletionMode={true}
            />
            <div className="d-flex w-100 justify-content-center mt-3">
                {!props.addingMode &&
                    <a className="btn btn-primary col-12" style={{ font: "inherit" }} onClick={() => props.setAddingMode(true)}>
                        Dołącz zgłoszenie
                    </a>
                }
                {props.addingMode &&
                    <div className="d-flex col-12 border-bottom border-dark-subtle pb-4">
                        <a
                            className="btn btn-outline-dark col-12"
                            style={{ font: "inherit" }}
                            onClick={() => props.setAddingMode(false)}
                        >
                            Anuluj dołączanie zgłoszenia
                        </a>
                    </div>
                }
            </div>
            {props.addingMode &&
                <div className="mt-3">
                    <CruiseApplicationsList
                        addingMode={true}
                        boundCruiseApplications={props.cruiseApplications}
                        setBoundCruiseApplications={updateApplications}
                    />
                </div>
            }
        </div>
    )
}