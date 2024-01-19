import React, {useEffect, useState} from 'react';
import Page from "../Tools/Page";
import UserImg from "../../resources/user.png"
import ErrorCode from "../LoginPage/ErrorCode";
import {FieldValues, useForm} from "react-hook-form";


function AccountPage(props:{className?: string}){
    const [ loading, setLoading ] = useState(false);
    const [ loading2, setLoading2 ] = useState(false);


    const [credentials, setCredentials] = useState( {name:"", surname:"", mail:"", role:""})//

    useEffect(() => {
        async function getCredentials() {
            try {
                const  response = await fetch('http://localhost:8080/account/changeMail', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                })
                    .then(data => {
                        if(data.status == 401) setChangeMailError("Podano obecny adres e-mail");
                        else if(!data.ok) setChangeMailError("Wystąpił problem ze zmianą adresu e-mail")
                        else return data.json();
                    })
                setCredentials(response)
            }
            catch (e){
                setCredentials({name:"Wills", surname:"Smith", mail:"www@ug.com", role:"admin"})
            }



        }

        // Wywołaj funkcję do pobierania danych po zamontowaniu komponentu
        getCredentials();

    }, [])

    const {
        register,
        handleSubmit,
        formState: { errors } } = useForm({
        mode: 'onSubmit',
    });
    const {
        watch,
        register:register2,
        handleSubmit:handleSubmit2,
        formState: { errors:errors2  } } = useForm({
        mode: 'onSubmit',
    });

    async function changeMail(data:FieldValues) {
        return fetch('http://localhost:8080/account/changeMail', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(data => {
                if(data.status == 401) setChangeMailError("Podano obecny adres e-mail");
                else if(!data.ok) setChangeMailError("Wystąpił problem ze zmianą adresu e-mail")
                else return data.json();
            })
    }

    const handleMailChange =   async (data:FieldValues) => {
        setLoading(true);
        try {
            await changeMail(data);
            setChangeMailError(null)
            // setRegisterSuccessful(true)
        }
        catch (e){
            setChangeMailError("Wystąpił problem ze zmianą adresu e-mail, sprawdź połączenie z internetem")
        }
        setLoading(false)
    }

    async function changePassword(data:FieldValues) {
        return fetch('http://localhost:8080/account/changePassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(data => {
                if(data.status == 401) setChangePasswordError("Podano obecne hasło");
                else if(!data.ok) setChangePasswordError("Wystąpił problem ze zmianą hasła")
                else return data.json();
            })
    }

    const handlePasswordChange =   async (data:FieldValues) => {
        const { password2, ...dataWithoutPassword2 } = data;
        setLoading2(true);
        try {
            await changePassword(dataWithoutPassword2);
            setChangePasswordError(null)
            // setRegisterSuccessful(true)
        }
        catch (e){
            setChangePasswordError("Wystąpił problem ze zmianą hasła, sprawdź połączenie z internetem")
        }
        setLoading2(false)
    }


    const [changeMailError, setChangeMailError] = useState<null|string>(null)
    const [changePasswordError, setChangePasswordError] = useState<null|string>(null)
    return (
        <>
            <Page className={props.className + " justify-content-center "}>
                <div className="bg-white w-100 d-flex flex-column pb-1 m-2 center align-self-start justify-content-center p-2">
                   <h1 style={{fontSize:"2rem"}}>Ustwienia konta <span className={"text-danger"}> {errors ? "!":""}</span></h1>
                    <div className={"d-flex flex-row flex-wrap justify-content-center  p-2 p-xl-5 align-items-center"}>

                        <div
                            className={" h4 col-12 col-xl-7 p-2 pt-3 d-flex flex-column justify-content-center justify-content-xl-start text-center   "}>
                            <img style={{width: "300px"}} className={"align-self-center border border-5 rounded m-2 "}
                                 src={UserImg}></img>
                            <div className={" h6 "}>
                                {credentials["role"]}

                            </div>
                            <div className={"p-1  "}>
                                {credentials["name"] + " " + credentials["surname"]}
                                {credentials["name"] && <ErrorCode code={"użytkownik nie został zaakceptowany"}/>}
                            </div>

                            <div className={"p-1 h5"}>
                                {credentials["mail"]}
                                {credentials["mail"] && <ErrorCode code={"email nie został potwierdzony"}/>}
                            </div>


                        </div>
                        <div
                            className={" h4 col-12 col-xl-5 p-2 pt-3 d-flex flex-column justify-content-center justify-content-xl-start  text-center "}>


                            <form className={`p-0 h6`}
                                  onSubmit={handleSubmit(handleMailChange)}>
                                <div className="txt_field">
                                    <input type="text" disabled={loading} {...register("email", {
                                        required: "Pole wymagane", maxLength: 30, pattern: {
                                            value: /\b[A-Za-z0-9._%+-]+@ug\.edu\.pl\b/,
                                            message: 'Podaj adres e-mail z domeny @ug.edu.pl',
                                        }
                                    })}/>
                                    <span></span>
                                    <label>Adres e-mail</label>
                                </div>
                                {errors["email"] && <ErrorCode code={errors["email"].message}/>}
                                <input className={loading ? "textAnim" : ""} type="submit" disabled={loading}
                                       value="Zmień adres email"/>
                                {changeMailError && <ErrorCode code={changeMailError}/>}
                            </form>

                            <form className={`p-0 h6`}
                                  onSubmit={handleSubmit2(handlePasswordChange)}>
                                <div className="txt_field">
                                    <input type="password" disabled={loading2} {...register2("password0", {
                                        required: "Pole wymagane", maxLength: 30, pattern: {
                                            value: /\b(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}\b/,
                                            message: 'Co najmniej 8 znaków w tym przynajmniej jedna duża litera, mała litera oraz cyfra',
                                        }
                                    })}/>
                                    <span></span>
                                    <label>Stare hasło</label>
                                </div>
                                {errors2["password"] && <ErrorCode code={errors2["password"].message}/>}
                                <div className="txt_field">
                                    <input type="password" disabled={loading2} {...register2("password", {
                                        required: "Pole wymagane", maxLength: 30, pattern: {
                                            value: /\b(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}\b/,
                                            message: 'Co najmniej 8 znaków w tym przynajmniej jedna duża litera, mała litera oraz cyfra',
                                        }
                                    })}/>
                                    <span></span>
                                    <label>Nowe hasło</label>
                                </div>
                                {errors2["password"] && <ErrorCode code={errors2["password"].message}/>}
                                <div className="txt_field">
                                    <input type="password" disabled={loading2} {...register2("password2", {
                                        required: "Pole wymagane", maxLength: 30,
                                        validate: (value) => value === watch('password') || 'Hasła nie pasują do siebie',
                                    })}/>
                                    <span></span>
                                    <label>Potwierdź hasło</label>
                                </div>
                                {errors2["password2"] && <ErrorCode code={errors2["password2"].message}/>}
                                <input className={loading2 ? "textAnim" : ""} type="submit" disabled={loading2}
                                       value="Zmień hasło"/>
                                {changePasswordError && <ErrorCode code={changePasswordError}/>}
                            </form>
                        </div>
                    </div>
                </div>
            </Page>
        </>
    )
}

export default AccountPage