import {
    Controller, FieldValues, useFormContext, UseFormReturn,
} from "react-hook-form";
import React, {useContext} from "react";
import FieldWrapper from "./FieldWrapper";
import {FormContext, FormValues} from "../Wrappers/FormTemplate";
import {readyFieldOptions} from "../Wrappers/ReactSelectWrapper";

export type FieldProps = {
    className?: string,
    fieldName: string,
    fieldLabel: string
}
type Props = FieldProps & {
    initValues?: string[],
}


function FormRadio(props: Props) {
    const formContext = useContext(FormContext)

    const render = ({field}:FieldValues) => {
        const fieldName = props.fieldName
        const RadioOption = (props:{option:string,index:number}) => (
            <input key={props.index} disabled={formContext!.readOnly}
                   className={`${field.value === props.index ? "radio-button-selected" : "radio-button-not-selected"}`}
                   type={"button"} value={props.option}
                   onClick={() => formContext!.setValue(fieldName, props.index, readyFieldOptions)}
            />
        )
        return (
            <div className="d-flex flex-column justify-content-center align-content-center">
                {props.initValues?.map((option, index) => (
                    <RadioOption key={index} option={option} index={index} />
                ))}
            </div>
        )
    }


    const fieldProps = {
        ...props,
        rules: {required: 'Wybierz jedną z opcji'},
        render: render,
    }

    return ( <FieldWrapper {...fieldProps}/> );
}


export default FormRadio