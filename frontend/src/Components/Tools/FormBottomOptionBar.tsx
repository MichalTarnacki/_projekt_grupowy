import {DownloadButtonDefault, ResendButton, SaveMenu} from "./SaveMenu";
import React, {useContext, useState} from "react";
import {FormContext} from "../Pages/FormPage/Wrappers/FormTemplate";
import {handlePrint, handleSave, handleSubmit} from "./FormButtonsHandlers";
import {ReactComponent as CancelIcon}  from "/node_modules/bootstrap-icons/icons/x-lg.svg";
import {extendedUseLocation} from "../Pages/FormPage/FormPage";
import Api from "./Api";
import api from "./Api";
import {_} from "react-hook-form/dist/__typetest__/__fixtures__";
import {useNavigate} from "react-router-dom";
import {Path} from "./Path";

const SupervisorMenu = () => {
    const location = extendedUseLocation()
    const [response, setResponse] = useState<undefined|string>(undefined)
    const acceptPatch = (accept:string) => Api.patch(`/api/CruiseApplications/${location?.state.cruiseApplicationId}
    /supervisorAnswer?accept=${accept}&supervisorCode=${location?.state.supervisorCode}`,
        null, {raw:true}).catch(err=>{ setResponse(err.request.response); throw err})
    const accept = () => acceptPatch("true")
        .then(_=>setResponse("Zgłoszenie zostało zaakceptowane")).catch(err=>{})

    const deny = () =>  acceptPatch("false")
        .then(_=>setResponse("Zgłoszenie zostało odrzucone")).catch(err=>{})



    const AcceptButton = () => {
        return (<button onClick={accept} className="form-page-option-button-default"> Zaakceptuj zgłoszenie </button>)
    }

    const DenyButton = () => (
        <button onClick={deny} className="form-page-option-button bg-danger w-100"> Odrzuć zgłoszenie </button>
    )

    return(
        <>
            {!response &&
                <>
                    <AcceptButton/>
                    <DenyButton/>
                </>
            }
            {response && <div className={"text-center justify-content-center w-100 p-2"}> {response} </div>}

        </>
    )
}


const SendMenu = () => {
    const [enabled, setEnabled] = useState(false)
    const formContext = useContext(FormContext)
    const Button = () => {
        const onClickAction = () => {
            formContext!.setReadOnly(true)
            setEnabled(true)
        }
        return (
            <button onClick={formContext?.handleSubmit(onClickAction)} className="form-page-option-button-default"> Wyślij </button>
        )
    }

    const CancelButton = () => (
        <div className={"form-page-option-note-button-small"} onClick={() => {
            setEnabled(false)
            formContext!.setReadOnly(false)
        }
        }>
            <CancelIcon/>
        </div>
    )

    const Points = () => (
        <div className="text-primary pt-2 text-center"> Obliczona liczba punktów: 5 </div>
    )
    const ConfirmSendButton = () => {
        const formContext = useContext(FormContext)
        const navigate = useNavigate()
        const handleSubmit = () => Api.post("/api/CruiseApplications/", formContext?.getValues()).then(()=>navigate(Path.CruiseApplications))
        const onClickAction = formContext!.handleSubmit(handleSubmit)
        return (
            <button onClick={onClickAction} className="form-page-option-button w-100"> Potwierdź </button>
        )
    }

    return {
        Menu:()=>(
            <div className={"d-flex flex-column w-100"}>
                <Points/>
                <div className={"d-flex flex-row w-100"}>
                    <ConfirmSendButton/>
                    <CancelButton/>
                </div>
            </div>
        ),
        Button: Button,
        enabled:enabled

    }
}

const PrintButton = () => ( <button onClick={handlePrint} className="form-page-option-button-default"> Drukuj </button> )


export const BottomOptionBar = () => {
    const formContext = useContext(FormContext)
    const saveMenu = SaveMenu()
    const sendMenu = SendMenu()
    const location = extendedUseLocation()

    const EditableFormButtons = () => (
        <>
            {!sendMenu.enabled && <saveMenu.saveButton/>}
            {!saveMenu.enabled && <sendMenu.Button/>}
        </>
    )

    const ReadonlyFormButtons = () => (
        <>
            <PrintButton/>
            <ResendButton/>
            <DownloadButtonDefault/>
        </>
    )

    const DefaultMenu = () => (
        <>
            {!formContext!.readOnly && <EditableFormButtons/> }
            {formContext!.readOnly && <ReadonlyFormButtons/> }
        </>
    )





    return(
    <div className="form-page-option-bar">
        {location?.state.supervisorCode && <SupervisorMenu/>}
        {!location?.state.supervisorCode &&
            <>
                {!saveMenu.enabled && !sendMenu.enabled && <DefaultMenu/>}
                {saveMenu.enabled && <saveMenu.menu/>}
                {sendMenu.enabled && <sendMenu.Menu/>}
            </>
        }

    </div>)
}