import React from 'react';
import Style from "./Page.module.css"


type Props = {
    className?: string,
    bgStyle?: any,
    children?: React.ReactElement<any, string | React.JSXElementConstructor<HTMLElement>>
}


function Page(props: Props){
    return (
        <>
            <div className={`${props.bgStyle ?? Style.bgImage} ${Style.bg}`} />
            <div className="h-100 w-100 d-flex flex-column">
                <div className="m-0 p-0 w-100 d-flex flex-row flex-shrink-0"
                     style={{"height": "84.3px"}}
                />
                <div className="container-xxl d-flex flex-column p-2 overflow-auto">
                    <div className={props.className + " d-flex w-100 flex-row h-100"}>
                        {props.children}
                    </div>
                </div>
            </div>
        </>
    )
}


export default Page