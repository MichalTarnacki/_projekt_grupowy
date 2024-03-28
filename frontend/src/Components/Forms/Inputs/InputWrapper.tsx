import ErrorCode from "../../LoginPage/ErrorCode";
import React from "react";


type Props = any


function InputWrapper(props: Props) {
    return (
        <div className={props.className + ` d-flex flex-column ${props.customError ? 'pb-0': ''} p-3 `}>
            <div>{props.label}</div>
            {props.children}
            {!props.customError && props.form.formState.errors[props.name] &&
                <ErrorCode code={props.form.formState.errors[props.name].message} />
            }
        </div>
    )
}


export default InputWrapper