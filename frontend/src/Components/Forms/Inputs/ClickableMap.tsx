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
import Map from 'src/resources/GraniceSamorzadow.jpg'
import InputWrapper from "./InputWrapper";
import {administrationUnits} from "../../../resources/administrationUnits";
import Select from "react-select";


type Props = {
    className?: string,
    label: string,
    name: string,
    required?: boolean,
    form?
}


function ClickableMap(props: Props) {
    const [clickPosition, setClickPosition] =
        useState({ x: 0, y: 0 });
    const imageRef = useRef(null);

    const regions = [
        [
            "Gdynia",
            [301, 263, 294, 370, 472, 565, 541, 407],
            [316, 392, 435, 408, 407, 311, 290, 272]
        ],
        [
            "Gdańsk",
            [479, 392, 374, 300, 304, 356, 400, 464, 522, 582, 653, 566],
            [409, 415, 456, 437, 549, 540, 598, 523, 538, 598, 384, 314]
        ],
        ["Woda",
            [172, 251, 279, 322, 361, 473, 533, 795, 964, 1144, 1129, 172, 0, 3, 175],
            [62, 66, 94, 115, 139, 205, 286, 507, 415, 152, 6, 6, 2, 95, 76]
        ]
    ]

    const handleClick = (e) => {
        const boundingRect = imageRef.current.getBoundingClientRect();
        const offsetX = e.clientX - boundingRect.left;
        const offsetY = e.clientY - boundingRect.top;

        regions.forEach((region)=> {
            if (isInside({ x: offsetX, y: offsetY }, region[1], region[2]))
                props.form.setValue(props.name, region[0], { shouldDirty: true, shouldTouch:true });
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

    console.log()

    return (
        <InputWrapper {...props}>
            <Controller
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
                            value={{label: field.value, value:field.value}}
                                options={regions.map(value => ({label: value[0], value:value[0]}))}
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