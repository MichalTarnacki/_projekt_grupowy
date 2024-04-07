import React, {useState} from 'react';
import Logo from "../../resources/logo.svg"
import DesktopMenu from "./DesktopMenu";
import MobileMenu from "./MobileMenu";


type Props = {
    className?: string,
    name?: string | null
}


function PageHeader(props: Props) {
    const [toggledButton, setToggle] = useState(false)

    return(
        <div className="fixed-top">
            <div className={props.className+ " bg-primary fixed-top text-light w-100 z-1 appHeader"}
            >
                <div className="navbar navbar-light h-100 w-100 ">
                    <div className="d-flex container-xxl flex-row justify-content-start flex-nowrap  h-100
                                    w-100"
                    >
                        <a className="navbar-brand pe-3 h-100 border-end"
                           href="https://ug.edu.pl/"
                           title="Strona główna"
                           rel="home"
                        >
                            <img src={Logo} alt="Strona główna" className="d-inline align-top h-100" />
                        </a>
                        <div className="h-100 text-light text-nowrap align-self-center text-center navbar me-3">
                            {props.name && "Witaj, " + props.name}
                        </div>
                        <button className="d-md-flex d-md-none navbar-toggler navbar-dark ms-auto me-0 pe-3"
                                onClick={() => setToggle(!toggledButton)}
                        >
                            <span className="navbar-toggler-icon" />
                        </button>
                        <div className="d-none d-md-flex ms-auto me-0 pe-3">
                            <DesktopMenu />
                        </div>
                    </div>
                </div>
            </div>

            <div className="m-0 p-0 appHeader" />
            <div className="m-0 p-0 fixed-top z-0 bg-primary">
                <div className="m-0 p-0 appHeader"/>
                <div className={`${toggledButton ? "flex-row d-md-flex" : "d-none" } d-md-none`}
                     style={{"height":"42.25px"}}
                >
                    <MobileMenu />
                </div>
            </div>
        </div>
    );
}


export default PageHeader