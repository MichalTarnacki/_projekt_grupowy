import React, {useState} from "react";
import {useForm} from "react-hook-form";
import FormTemplate from "../Wrappers/FormTemplate";
import FormTitle from "../CommonComponents/FormTitle";
import FormUserSelect from "../Inputs/FormUserSelect";
import FormCreatableSelect from "../Inputs/FormCreatableSelect";
import FormSection from "../Wrappers/FormSection";
import MonthSlider from "../Inputs/MonthSlider";
import NumberInput from "../Inputs/NumberInput";
import TextArea from "../Inputs/TextArea";
import FormRadio from "../Inputs/FormRadio";
import ClickableMap from "../Inputs/ClickableMap";
import TaskInput from "../Inputs/TaskInput/TaskInput";
import BlockList from "../Inputs/UgTeamsInput/UgTeamsInput";
import GuestTeamsInput from "../Inputs/GuestTeamsInput/GuestTeamsInput";
import SpubTasksInput from "../Inputs/SpubTasksInput";
import {DummyTag} from "../../../Tools/DummyTag";
import FormWithSections from "../Wrappers/FormWithSections";
import ContractsInput from "../Inputs/ContractsInput/ContractsInput";


function FormC(props:{loadValues?:any}){

    const form = useForm({
        mode: 'onBlur',
        // defaultValues: defaultValues,
        shouldUnregister: false
    });


    const [sections, setSections] = useState({
        "Kierownik":"Kierownik zgłaszanego rejsu",
        "Czas":"Czas trwania zgłaszanego rejsu",
        "Pozwolenia": "Dodatkowe pozwolenia do planowanych podczas rejsu badań",
        "Rejon": "Rejon prowadzenia badań",
        "Cel": "Cel Rejsu",
        "Zadania": "Zadania do zrealizowania w trakcie rejsu",
        "Umowy": "Umowy regulujące współpracę, w ramach której miałyby być realizowane zadania badawcze",
        "Z. badawcze": "Zespoły badawcze, jakie miałyby uczestniczyć w rejsie",
        "Publikacje/prace": "Publikacje i prace",
        "SPUB": "Zadania SPUB, z którymi pokrywają się zadania planowane do realizacji na rejsie"
    })

    return (
        <FormTemplate form={form} loadValues={props.loadValues} type='C'>
            <FormTitle sections={sections} title={"Formularz C"} />
            <FormWithSections sections={sections} form={form}>
                <FormSection title={sections.Kierownik}>
                    <FormCreatableSelect className="col-12 col-md-6 col-xl-3"
                                         name="managers"
                                         label="Kierownik rejsu"
                                         values={["sss"]}
                    />
                    <FormUserSelect className="col-12 col-md-6 col-xl-3"
                                    name="supplyManagers"
                                    label="Zastępca"
                                    values={["sss"]}
                    />
                    <FormUserSelect className="col-12 col-md-6 col-xl-3"
                                    name="years"
                                    label="Rok rejsu"
                                    values={["sss"]}
                    />
                </FormSection>

                <FormSection title={sections.Czas}>
                    <MonthSlider className="col-12 col-md-12 col-xl-6 p-4 pb-0 pt-2"
                                 name="acceptedPeriod"
                                 connectedName="optimalPeriod"
                                 label="Dopuszczalny okres, w którym miałby się odbywać rejs:"
                    />
                    <MonthSlider className="col-12 col-md-12 col-xl-6 p-4 pb-0 pt-2"
                                 name="optimalPeriod"
                                 range={form.getValues("acceptedPeriod")}
                                 label="Optymalny okres, w którym miałby się odbywać rejs"
                    />
                    <NumberInput className="col-12 col-md-12 col-xl-6"
                                 name="cruiseDays"
                                 label="Liczba planowanych dób rejsowych"
                                 connectedName="cruiseTime"
                                 notZero
                                 newVal={(e) => 24*e}
                                 maxVal={99}
                    />
                    <NumberInput className="col-12 col-md-12 col-xl-6"
                                 notZero
                                 name="cruiseTime"
                                 label="Liczba planowanych godzin rejsowych"
                                 connectedName="cruiseDays"
                                 newVal={(e) => Number((e/24).toFixed(2))}
                                 maxVal={99}
                    />
                    <TextArea className="col-12 p-3"
                              required={false}
                              label="Uwagi dotyczące teminu"
                              name="notes"
                    />
                    <FormRadio className="col-12 col-md-12 col-xl-6 p-3"
                               label="Statek na potrzeby badań będzie wykorzystywany:"
                               name="shipUsage"
                               values={[
                                   "całą dobę",
                                   "jedynie w ciągu dnia (maks. 8–12 h)",
                                   "jedynie w nocy (maks. 8–12 h)",
                                   "8–12 h w ciągu doby rejsowej, ale bez znaczenia o jakiej porze albo z założenia" +
                                   "o różnych porach",
                                   "w inny sposób"
                               ]}
                    />
                    {(() => {
                        if (form.watch("shipUsage") == "w inny sposób" ) {
                            return (
                                <TextArea className="col-12 col-md-12 col-xl-6 p-3"
                                          label="Inny sposób użycia"
                                          name="diffrentUsage"
                                          required="Podaj sposób użycia"
                                />
                            )
                        }
                        else
                            return <DummyTag required={false} />
                    })()}
                </FormSection>

                <FormSection title={sections.Pozwolenia}>
                    <FormRadio className="col-12 col-md-12 col-xl-6 p-3"
                               label="Czy do badań prowadzonych podczas rejsu są potrzebne dodatkowe pozwolenia?"
                               name="permissions"
                               values={["tak", "nie"]}
                    />
                    {(() => {
                        // @ts-ignore
                        if (form.watch("permissions") == "tak" ) {
                            return (
                                <TextArea className="col-12 col-md-12 col-xl-6 p-3"
                                          label="Jakie?"
                                          name="additionalPermissions"
                                          required="Podaj jakie"
                                />
                            )
                        }
                        else
                            return <DummyTag required={false} />
                    })()}
                </FormSection>

                <FormSection title={sections.Rejon}>
                    <ClickableMap label="Obszar prowadzonych badań" name="area" />
                    <TextArea className="col-12 col-md-12 col-xl-6 p-3"
                              required={false}
                              label="Opis"
                              name="areaInfo"
                    />
                </FormSection>

                <FormSection title={sections.Cel}>
                    <FormRadio className="col-12 col-md-12 col-xl-6 p-3"
                               label="Cel rejsu"
                               name="goal"
                               values={["Naukowy", "Komercyjny", "Dydaktyczny"]}
                    />
                    <TextArea className="col-12 col-md-12 col-xl-6 p-3"
                              label="Opis"
                              name="goalaInfo"
                              required="Opisz cel"
                    />
                </FormSection>

                <FormSection title={sections.Zadania}>
                    <TaskInput name={"wejscie"} historicalTasks={[

                        {
                            "type": 5,
                            "values": {
                                "title": "3re",
                                "time": {
                                    "startDate": "Mon Jan 01 2024 00:00:00 GMT+0100 (czas środkowoeuropejski standardowy)",
                                    "endDate": "Sun Dec 01 2024 00:00:00 GMT+0100 (czas środkowoeuropejski standardowy)"
                                },
                                "financingAmount": "0.00"
                            }
                        },
                        {
                            "type": 5,
                            "values": {
                                "title": "3re",
                                "time": {
                                    "startDate": "Wed May 01 2024 00:00:00 GMT+0200 (czas środkowoeuropejski letni)",
                                    "endDate": "Wed May 01 2024 00:00:00 GMT+0200 (czas środkowoeuropejski letni)"
                                },
                                "financingAmount": "0.00"
                            }
                        },
                        {
                            "type": 11,
                            "values": {
                                "description": "rtetretret"
                            }
                        },
                        {
                            "type": 3,
                            "values": {
                                "title": "fsdfds",
                                "institution": "ffsdff",
                                "date": "Fri Mar 15 2024 00:00:00 GMT+0100 (czas środkowoeuropejski standardowy)"
                            }
                        },
                        {
                            "type": 0,
                            "values": {
                                "author": "sdfdsf",
                                "title": "dsfdfsd"
                            }
                        }
                    ]} className={"col-12"} label={"ss"}/>
                </FormSection>

                <FormSection title={sections.Umowy}>
                    <ContractsInput
                        className="col-12"
                        name="contracts"
                        historicalContracts={[
                            {
                                category: "international",
                                institution: {
                                    name: "Instytucja 1",
                                    unit: "Jednostka 1",
                                    localization: "Lokalizacja 1"
                                },
                                description: "Opis 1",
                                scan: {
                                    name: "Skan 1",
                                    content: "1111111111"
                                }
                            },
                            {
                                category: "international",
                                institution: {
                                    name: "Instytucja 2",
                                    unit: "Jednostka 2",
                                    localization: "Lokalizacja 2"
                                },
                                description: "Opis 2",
                                scan: {
                                    name: "Skan 2",
                                    content: "222222222"
                                }
                            },
                            {
                                category: "domestic",
                                institution: {
                                    name: "Instytucja 3",
                                    unit: "Jednostka 3",
                                    localization: "Lokalizacja 3"
                                },
                                description: "Opis 3",
                                scan: {
                                    name: "Skan 3",
                                    content: "3333333333"
                                }
                            },
                            {
                                category: "domestic",
                                institution: {
                                    name: "Instytucja 4",
                                    unit: "Jednostka 4",
                                    localization: "Lokalizacja 4"
                                },
                                description: "Opis 4",
                                scan: {
                                    name: "Skan 4",
                                    content: "444444444"
                                }
                            }
                        ]}
                        required={false}
                    />
                </FormSection>

                <FormSection title={sections["Z. badawcze"]}>
                    <GuestTeamsInput required={false} className={"col-12 col-xl-6 "} label={"Uczestnictwo naukowców z jednostek organizacyjnych UG spoza WOiG"} name={"blockListInput"}/>
                    <BlockList className={"col-12 col-xl-6"} label={"Uczestnictwo osób z jednostek organizacyjnych UG"} name={"blockList"}/>

                </FormSection>
                <FormSection title={sections["Publikacje/prace"]}>
                    <DummyTag/>
                </FormSection>

                <FormSection title={sections.SPUB}>
                    <SpubTasksInput
                        className="col-12"
                        name="spubTasks"
                        historicalSpubTasks={[
                            {
                                yearFrom: "2020",
                                yearTo: "2030",
                                name: "Badanie nowych właściwości wodno-tlenowych Morza Bałtyckiego w obszarze Zatoki Gdańskiej"
                            },
                            {
                                yearFrom: "2021",
                                yearTo: "2026",
                                name: "Badanie właściwości azotowych Morza Bałtyckiego w obszarze Zatoki Puckiej"
                            },
                            {
                                yearFrom: "2022",
                                yearTo: "2024",
                                name: "Bałtycki pobór zasobów mineralnych na obszarze Polskiej WSE"
                            },
                        ]}
                        required={false}
                    />
                </FormSection>

            </FormWithSections>
        </FormTemplate>
    )
}


export default FormC