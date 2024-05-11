import {
    Control,
    Controller,
    FieldError,
    FieldErrorsImpl,
    FieldValues,
    Merge,
} from "react-hook-form";
import React, {useRef, useState} from "react";
import ErrorCode from "../../LoginPage/ErrorCode";
import Map from '../../../../resources/GraniceSamorzadow.jpg'
import InputWrapper from "./InputWrapper";
import {administrationUnits} from "../../../../resources/administrationUnits";
import Select from "react-select";


type Props = {
    className?: string,
    label: string,
    name: string,
    required?: boolean,
    regions?: [{Name:string, X:number[], Y:number[]}]
    form?
}


function ClickableMap(props: Props) {
    const [clickPosition, setClickPosition] =
        useState({ x: 0, y: 0 });
    const imageRef = useRef(null);


    const handleClick = (e) => {
        const boundingRect = imageRef.current.getBoundingClientRect();
        const offsetX = e.clientX - boundingRect.left;
        const offsetY = e.clientY - boundingRect.top;

        regions?.forEach((region, index)=> {
            if (isInside({ x: offsetX, y: offsetY }, region.X, region.Y))
                props.form.setValue(props.name, index, { shouldDirty: true, shouldTouch:true });
            // setClickPosition({ x: offsetX, y: offsetY });
        })
    }

    const isInside = (point: { x: any; y: any; }, xArr, yArr) => {
        const x = point.x;
        const y = point.y;

        let inside = false;
        for (let i = 0, j = xArr.length - 1; i < xArr.length; j = i++) {
            const xi = xArr[i];
            const yi = yArr[i];
            const xj = xArr[j];
            const yj = yArr[j];

            const intersect =
                yi > y !== yj > y && x < ((xj - xi) * (y - yi)) / (yj - yi) + xi;

            if (intersect)
                inside = !inside;
        }

        return inside;
    };

    // console.log()

    return (
        <InputWrapper {...props}>
            <Controller
                defaultValue={""}
                render={({ field}) =>
                    <div className="d-flex flex-column">
                        <Select minMenuHeight={300}
                            // className={"text-white"}
                                menuPlacement="auto"
                                placeholder={"Wybierz opcję lub wyszukaj"}
                                styles={{
                                    menu: provided => ({...provided, zIndex: 9999})
                                }}
                                placeHolder={"Wybierz"}
                            // styles={{}}
                            value={{label:((props.regions && field.value !== "") ? props.regions[field.value].Name : ""), value:field.value}}
                                options={props.regions?.map((value, index) => ({label: value.Name, value:index}))}
                            // closeMenuOnScroll={() => true}
                                onChange={(selectedOption) => {
                                    props.form.setValue(props.name, selectedOption.value, { shouldDirty: true, shouldTouch:true });

                                }}
                        />
                        <img ref={imageRef}
                             className="shadow m-2 bg-white rounded w-100"
                             draggable={false}
                             style={{cursor: "pointer"}}
                             src={Map}
                             alt="Obszary"
                             onClick={handleClick}
                        />
                    </div>
                }
                name={props.name}
                control={props.form.control}
                rules={{
                    required: "Wybierz obszar"
                }}
            />
        </InputWrapper>
    )
}


export default ClickableMap