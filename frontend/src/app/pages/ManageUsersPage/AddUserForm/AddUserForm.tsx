import { useForm } from 'react-hook-form';
import React, { useState } from 'react';
import TextInput from './TextInput';
import RoleInput from './RoleInput';

import { emailPattern } from '@consts/emailPatterns';

import {
    ErrorMessageIfPresentNoContext,
} from '@components/Form/ErrorMessage/ErrorMessageIfPresentNoContext';
import Api from '../../../../api/Api';
import SuccessMessage from '../../../../ToBeMoved/Pages/CommonComponents/SuccessMessage';
import { Role } from 'Role';
import { NewUserFormValues } from 'NewUserFormValues';
import { AxiosRequestConfig } from 'axios';

type Props = {
    fetchUsers: () => void;
};

export default function AddUserForm(props: Props) {
    const newUserFormDefaultValues: NewUserFormValues = {
        role: Role.CruiseManager,
        email: '',
        firstName: '',
        lastName: '',
    };
    const newUserForm = useForm<NewUserFormValues>({
        defaultValues: newUserFormDefaultValues,
    });

    const [showDropDown, setShowDropDown] = useState(false);
    const [sending, setSending] = useState(false);
    const [sendingError, setSendingError] = useState('');
    const [success, setSuccess] = useState(false);

    const handleSubmit = () => {
        setSendingError('');
        setSuccess(false);
        setSending(true);
        Api.post('/users', newUserForm.getValues(), { raw: true } as AxiosRequestConfig)
            .then((response) => {
                setSending(false);
                setSuccess(true);
                props.fetchUsers();
            })
            .catch((error) => {
                setSendingError(error.response.data);
                setSending(false);
            });
    };

    return (
        <div className="d-flex flex-wrap p-3 col-12">
            <a
                className="d-flex btn btn-primary mb-2"
                style={{ fontSize: 'inherit' }}
                onClick={() => setShowDropDown(!showDropDown)}
            >
                Nowy użytkownik {showDropDown ? ' ▲' : ' ▼'}
            </a>
            {showDropDown && (
                <div className="d-flex row flex-wrap w-100  rounded-2">
                    <RoleInput
                        form={newUserForm}
                        label="Rola"
                        name="role"
                        disabled={sending}
                    />
                    <TextInput
                        form={newUserForm}
                        label="E-mail"
                        name="email"
                        validationPattern={emailPattern}
                        validationPatternMessage="Nieprawidłowy adres e-mail"
                        disabled={sending}
                    />
                    <TextInput
                        form={newUserForm}
                        label="Imię"
                        name="firstName"
                        disabled={sending}
                    />
                    <TextInput
                        form={newUserForm}
                        label="Nazwisko"
                        name="lastName"
                        disabled={sending}
                    />

                    <div className="d-flex w-100 mt-1 justify-content-end">
                        <a
                            className={`btn btn-primary ${sending ? 'disabled' : ''}`}
                            type="submit"
                            style={{ fontSize: 'inherit' }}
                            onClick={newUserForm.handleSubmit(handleSubmit)}
                        >
                            Dodaj
                        </a>
                    </div>

                    <div className="d-flex col-12 justify-content-end">
                        {sendingError != '' && (
                            <ErrorMessageIfPresentNoContext
                                className="w-100"
                                message={sendingError}
                            />
                        )}
                        {success && (
                            <SuccessMessage
                                className="w-100"
                                message="Użytkownik dodany poprawnie"
                            />
                        )}
                    </div>
                </div>
            )}
        </div>
    );
}
