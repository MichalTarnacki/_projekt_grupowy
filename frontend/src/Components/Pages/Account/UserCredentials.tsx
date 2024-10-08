import userDataManager from "../../CommonComponents/UserDataManager";
import React, {useEffect, useState} from "react";
import {ErrorMessageIfPresentNoContext} from "../CommonComponents/ErrorMessageIfPresent";
import Question from "/node_modules/bootstrap-icons/icons/question.svg"
import Person from "/node_modules/bootstrap-icons/icons/person-bounding-box.svg"
import axios from "axios";

export function UserCredentials() {
    const [credentialsError, setCredentialsError] = useState("")
    const {userData, GetUserData} = userDataManager()
    useEffect(() => {
        try {
            (GetUserData)()
        }
        catch (error){
            if(axios.isAxiosError(error))
            setCredentialsError("Nie udało się pobrać danych")
        }
    }, []);


    const UserImage = () => (<img className="user-profile-image" src={Person} alt="Zdjęcie użytkownika"/>)
    const UserRoles = () => (<div className="h6">{userData?.roles}</div>)
    const UserIdentity = () => (
        <div className="p-1">
            {userData?.firstName + " " + userData?.lastName}
            {userData && !userData.accepted && <ErrorMessageIfPresentNoContext message="użytkownik nie został zaakceptowany"/>}
        </div>
    )
    const UserEmail = () => (
        <div className={"p-1 h5"}>
            {userData?.email}
            {userData && !userData.emailConfirmed && <ErrorMessageIfPresentNoContext message="email nie został potwierdzony"/>}
        </div>
    )

    const UserCredentialsData = () => (
        <>
            <UserImage/>
            <UserRoles/>
            <UserIdentity/>
            <UserEmail/>
        </>
    )
    const DataWithoutCredentials = () => (
        <>
            <img className="user-profile-image" src={Question} alt="Zdjęcie użytkownika"/>
            <ErrorMessageIfPresentNoContext message={credentialsError}/>
        </>
    )

    return (
        <div className={"w-100"}>
            {!credentialsError && userData && <UserCredentialsData/>}
            {credentialsError && <DataWithoutCredentials/>}
        </div>
    )
}