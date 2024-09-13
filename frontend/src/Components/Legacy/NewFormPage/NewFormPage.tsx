import React, {useState} from 'react';
import Page from "../../Pages/Page";
import {Link, useNavigate} from "react-router-dom";
import {FormPageLocationState} from "../../Pages/FormPage/FormPage";


type Props = {
    className?: string
}


function NewFormPage(props: Props) {
    const navigate = useNavigate()

    const navigateToFormPage = (formType: string) => {
        const locationState: FormPageLocationState = {
            formType: formType,
            readonly: false
        }
        navigate("/Form", {
            state: locationState
        })
    }

    return (
        <Page className={props.className + " d-flex p-3 justify-content-center bg-white"}>
            <div className="d-flex flex-column pb-1 m-2 center align-self-start justify-content-center w-100">
                <h1 style={{fontSize: "2rem"}}>Wybierz formularz</h1>

                <div className={"btn btn-info m-2"} onClick={() => navigateToFormPage("A")}>
                    Formularz A
                </div>
                <div className={"btn btn-info m-2"} onClick={() => navigateToFormPage("B")}>
                    Formularz B
                </div>
                <div className={"btn btn-info m-2"} onClick={() => navigateToFormPage("C")}>
                    Formularz C
                </div>

            </div>
        </Page>
    )
}


export default NewFormPage;