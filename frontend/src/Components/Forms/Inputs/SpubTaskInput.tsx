import React, {useEffect} from "react";
import {Controller, get, useFieldArray} from "react-hook-form";
import ErrorCode from "../../LoginPage/ErrorCode";


type Props = {
    className: string,
    label: string,
    name: string,
    form?
}

type SpubTask = {
    yearFrom: string | "",
    yearTo: string | "",
    name: string | ""
}


export default function SpubTaskInput(props: Props){
    const {
        fields,
        append,
        remove
    } = useFieldArray({
        control: props.form.control,
        name: props.name,
    });

    return (
        <div className={props.className + " p-3 d-flex flex-column justify-content-center"}>
            <table className="table-striped w-100">
                <thead className="text-white text-center" style={{"backgroundColor":"#052d73"}}>
                <tr className="d-flex flex-row center align-items-center w-100">
                    <td className="text-center p-2 w-100">{props.label}</td>
                </tr>
                </thead>

                <tbody>
                {!fields.length &&
                    <tr className="d-flex flex-row bg-light p-2 justify-content-center">
                        <td colSpan={3} className={"text-center"} >Brak</td>
                    </tr>
                }
                {fields.map((item, index) => (
                    <React.Fragment key={item.id}>
                        <tr className="d-flex flex-row justify-content-center align-items-center border bg-light">
                            <td className="text-center p-2 border-end" style={{"width": "10%"}}>{index}</td>
                            <th className="text-center p-2" style={{"width": "90%"}}>
                                {/*<Controller*/}
                                {/*    name={`${props.name}[${index}].yearFrom`}*/}
                                {/*    control={props.form.control}*/}
                                {/*    rules={{*/}
                                {/*        required: "Pole nie może być puste",*/}
                                {/*    }}*/}
                                {/*    render={({ field }) => (*/}
                                {/*        <input {...field}*/}
                                {/*               type="text"*/}
                                {/*        />*/}
                                {/*    )}*/}
                                {/*/>*/}
                                <Controller name={`${props.name}[${index}].value`}
                                            control={props.form.control}
                                            rules={{
                                                required: "Pole nie może być puste",
                                                validate: (value) =>
                                                    value.length < 10 || 'Pole nie może mieć wartości 0.'
                                            }}
                                            render={({ field }) => (
                                                <input {...field}
                                                       type="text"
                                                       className="w-100"
                                                />
                                            )}
                                />
                            </th>
                            <th className="d-inline-flex p-2">
                                <button type="button"
                                        className="btn btn-primary"
                                        onClick={() => {remove(index)}}
                                >
                                    -
                                </button>
                            </th>
                        </tr>
                        <tr className="bg-light">
                            <th>
                                {props.form.formState.errors[props.name] &&
                                    props.form.formState.errors[props.name][index] &&
                                    <ErrorCode
                                        code={props.form.formState.errors[props.name][index]["value"].message}
                                    />
                                }
                            </th>
                        </tr>
                    </React.Fragment>
                ))}
                </tbody>
            </table>

            <button className={`btn btn-primary ${props.form.formState.errors[props.name] ? "disabled" : ""}`}
                    type="button"
                    onClick={() => append({
                            yearFrom: "",
                            yearTo: "",
                            name: ""
                        })
                    }
            >
                +
            </button>
        </div>
    )
}