import React, {useEffect, useState} from "react";
import {registerLocale} from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import pl from "date-fns/locale/pl";
registerLocale("pl", pl);
import 'react-dropdown/style.css';
import ReadOnlyTextInput from "../../../CommonComponents/ReadOnlyTextInput";
import useWindowWidth from "../../../CommonComponents/useWindowWidth";

export type TaskValues =
    { author: string, title: string } |
    { title: string, institution: string, date: string} |
    { title: string, time: Time, financingAmount: number } |
    { description: string }

export type Time = {
    start: string,
    end: string
}

export const taskFieldsOptions= {
    'Praca licencjacka': ["Autor", "Tytuł" ],
    'Praca magisterska': ["Autor", "Tytuł" ],
    'Praca doktorska': ["Autor", "Tytuł" ],
    "Przygotowanie projektu naukowego": ["Tytuł", "Instytucja, do której składany", "Przewidywany termin składania"],
    "Realizacja projektu krajowego (NCN, NCBiR, itp.)": ["Tytuł", "Ramy czasowe", "Kwota finansowania"],
    "Realizacja projektu zagranicznego (ERC, Programy ramowe UE, fundusze norweskie, itp)": ["Tytuł", "Ramy czasowe", "Kwota finansowania"],
    "Realizacja projektu wewnętrznego UG": ["Tytuł", "Ramy czasowe", "Kwota finansowania"],
    "Realizacja innego projektu naukowego":["Tytuł", "Ramy czasowe", "Kwota finansowania"],
    "Realizacja projektu komercyjnego": ["Tytuł", "Ramy czasowe", "Kwota finansowania"],
    "Dydaktyka": ["Opis zajęcia dydaktycznego"],
    "Realizacja własnego zadania badawczego": ["Tytuł", "Ramy czasowe", "Kwota finansowania"],
    "Inne zadanie": ["Opis zadania"]
}


type EvaluatedTask = {
    type: number,
    values: TaskValues
    calculatedPoints: string
}

type Props = {
    evaluatedTasks: EvaluatedTask[]
}


function TasksPoints(props: Props) {
    const getTaskTitle = (task: EvaluatedTask) => {
        return Object.keys(taskFieldsOptions)[task.type]
    }

    const getFields = (evaluatedTask: EvaluatedTask) => {
        return Object.values(evaluatedTask.values)
    }

    const windowWidth = useWindowWidth()


    return (
        <div className="col-12 p-3">
            <>
                <div className="table-striped w-100">
                    <div className="text-white text-center bg-primary">
                        <div className="d-flex flex-row center align-items-center">
                            <div className="text-center d-none d-xl-block p-2" style={{width: "5%"}}>
                                <b>Lp.</b>
                            </div>
                            <div className="text-center d-none d-xl-block p-2" style={{width: "20%"}}>
                                <b>Zadanie</b>
                            </div>
                            <div className="text-center d-none d-xl-block p-2" style={{width: "66%"}}>
                                <b>Szczegóły</b>
                            </div>
                            <div className="text-center d-none d-xl-block p-2" style={{width: "9%"}}>
                                <b>Punkty</b>
                            </div>

                            <div className="text-center d-lg-block d-xl-none p-2 col-12">
                                <b>Zadania</b>
                            </div>
                        </div>
                    </div>
                    <div className="w-100">
                        {!props.evaluatedTasks.length &&
                            <div className="d-flex flex-row justify-content-center bg-light p-2 border">
                                <div className="text-center">Nie wybrano żadnego zadania</div>
                            </div>
                        }
                        {props.evaluatedTasks.map((row: EvaluatedTask, rowIndex: number) => (
                            <div
                                key={rowIndex}
                                className={`d-flex flex-wrap border-bottom border-start border-end ${rowIndex % 2 == 0 ? "bg-light" : "bg-white"}`}
                            >
                                <div className="d-none d-xl-flex justify-content-center align-items-center p-2"
                                     style={{width: "5%"}}
                                >
                                    {rowIndex + 1}.
                                </div>
                                <div className="d-flex d-xl-none justify-content-center align-items-center p-2 col-12">
                                    <b>Zadanie {rowIndex + 1}.</b>
                                </div>

                                <div className="text-center align-items-center justify-content-center p-2 d-inline-flex"
                                     style={{width: windowWidth >= 1200 ? "20%" : "100%"}}
                                >
                                    {getTaskTitle(row.researchTask)}
                                </div>
                                <div className="text-center d-flex"
                                     style={{width: windowWidth >= 1200 ? "66%" : "100%"}}
                                >
                                    <div className="d-flex flex-wrap justify-content-center justify-content-xl-start pb-3 w-100">
                                        {getFields(row.researchTask).map((val: string | Time, valIdx: number) => {
                                            return (
                                                <div key={valIdx}
                                                     className={`${getFields(row).length == 2 && "col-xl-6"} ${getFields(row).length == 3 && "col-xl-4"} col-12 p-2`}
                                                >
                                                    <label className="d-flex justify-content-center align-items-center">
                                                        {Object.values(taskFieldsOptions)[row.researchTask.type][valIdx]}
                                                    </label>
                                                    {(()=> {
                                                        switch (Object.values(taskFieldsOptions)[row.researchTask.type][valIdx]){
                                                            case "Autor":
                                                            case "Tytuł":
                                                            case "Instytucja, do której składany":
                                                            case "Opis zajęcia dydaktycznego":
                                                            case "Opis zadania":
                                                                return <ReadOnlyTextInput value={val as string} />

                                                            case "Przewidywany termin składania":
                                                                return (
                                                                    // <DatePicker
                                                                    //     showMonthYearPicker
                                                                    //     showMonthYearDropdown
                                                                    //     className={"text-center w-100 p-1 form-control"}
                                                                    //     style={{fontSize: "inherit"}}
                                                                    //     locale={"pl"}
                                                                    //     selected={val as Time}
                                                                    //     dateFormat="dd/MM/yyyy"
                                                                    //     readOnly
                                                                    // />
                                                                    <ReadOnlyTextInput value={val as string} />
                                                                )
                                                            case "Ramy czasowe":
                                                                return (
                                                                    <>
                                                                        {/*<DatePicker*/}
                                                                        {/*    showMonthYearPicker*/}
                                                                        {/*    showMonthYearDropdown*/}
                                                                        {/*    className={" text-center w-100 p-1 form-control"}*/}
                                                                        {/*    style={{fontSize: "inherit"}}*/}
                                                                        {/*    selectsStart*/}
                                                                        {/*    locale={"pl"}*/}
                                                                        {/*    selected={(val as Time).startDate ? new Date((val as Time).startDate) : null}*/}
                                                                        {/*    dateFormat="dd/MM/yyyy"*/}
                                                                        {/*    readOnly*/}
                                                                        {/*/>*/}
                                                                        <ReadOnlyTextInput value={(val as Time).start ? (val as Time).start : ""} />
                                                                        {/*<DatePicker*/}
                                                                        {/*    showYearDropdown*/}
                                                                        {/*    showMonthYearPicker*/}
                                                                        {/*    className={"text-center w-100 p-1 form-control"}*/}
                                                                        {/*    style={{fontSize: "inherit"}}*/}
                                                                        {/*    selectsEnd*/}
                                                                        {/*    locale={"pl"}*/}
                                                                        {/*    selected={(val as Time ).endDate ? new Date((val as Time ).endDate) : null}*/}
                                                                        {/*    dateFormat="dd/MM/yyyy"*/}
                                                                        {/*    readOnly*/}
                                                                        {/*/>*/}
                                                                        <ReadOnlyTextInput value={(val as Time).end ? (val as Time).end : ""} />
                                                                    </>
                                                                )
                                                            case "Kwota finansowania":
                                                                return <ReadOnlyTextInput value={val as string} />
                                                        }
                                                    })()}
                                                </div>
                                            )
                                        })}
                                    </div>
                                </div>
                                <div className="d-flex flex-wrap text-center p-2 justify-content-center border-start"
                                     style={{width: windowWidth >= 1200 ? "9%" : "100%"}}
                                >
                                    <div className="col-12 d-xl-none">Punkty:</div>
                                    <div className={"col-12 align-items-center justify-content-center d-flex"}>
                                        <ReadOnlyTextInput value={row.calculatedPoints} />
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </>
        </div>
    )
}


export default TasksPoints