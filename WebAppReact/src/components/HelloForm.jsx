import React from "react";
import "./HelloForm.scss";

const HelloForm = () => {
    const handleClickRegister = () => {
    }

    const handleClickLogin = () => {
    }

    return(
        <div className="HelloForm">
            <h1 className="HelloForm GridRow1">Hello!</h1>
            <button className="HelloForm GridRow2" onClick={handleClickRegister}>Register</button>
            <button className="HelloForm GridRow3" onClick={handleClickLogin}>Login</button>
        </div>
    );
}

export default HelloForm;
