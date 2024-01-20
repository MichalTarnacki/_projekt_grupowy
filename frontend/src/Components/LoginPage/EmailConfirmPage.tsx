import React, {useEffect, useState} from 'react';
import Style from './LoginPage.module.css'
import Page from "../Tools/Page";
import "./style.css"
import {Link, useLocation, useParams} from "react-router-dom";
function EmailConfirmPage(){
    const [confirmed, setConfirmed] = useState(false)
    const [errorMsg, setErrorMsg] = useState<null|string>(null)
    const [userIdParam] = useState()
    const { search } = useLocation();
    useEffect(() => {
        const searchParams = new URLSearchParams(search);
        const userIdParam = searchParams.get('userId');
        const codeParam = searchParams.get('code');

        async function confirmEmail() {
            try {
                const  response = await fetch(`http://localhost:8080/account/confirmEmail?userId=${userIdParam}&code=${codeParam}`, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'

                    },
                })
                    .then(data => {
                        if(data.ok)
                            return data.json();
                        else throw new Error("problem")
                    })
                setConfirmed(true)
            }
            catch (e){
                setErrorMsg(e.toString())

            }
        }
        confirmEmail();
    }, [])

    return (
        <>
            <Page bgStyle={Style.bgImage + " bg"} className={"justify-content-center justify-content-md-end " + Style}>
                        <div className=" d-flex flex-column pb-1 m-2 center align-self-start"
                             style={{minWidth: "300px", maxWidth: "400px", "background": "white"}}>
                            { confirmed &&
                                <div className="signup_link m-3 text-break">
                                    <div style={{fontSize:"1.3rem"}}>Email został potwierdzony</div>
                                    <div className={"butt p-2 mt-2"}>
                                        <Link className={"text-white"} to="/">
                                            Powrót do logowania
                                        </Link>
                                    </div>
                                </div>
                            }
                            { !confirmed &&
                                <div className="signup_link m-3 text-break">
                                    <div style={{fontSize:"1.3rem"}}>Nie udało się potwiedzić adresu email</div>
                                    <div className={"butt p-2 mt-2"}>
                                        <Link className={"text-white"} to="/">
                                            Powrót do logowania
                                        </Link>
                                    </div>
                                </div>

                            }
                        </div>

            </Page>
        </>
    )
}

export default EmailConfirmPage