import { useState } from "react";
import { postCustomer } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import { useNavigate } from "react-router-dom";

function NewCustomer(props:any) {

    const navigate = useNavigate()
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');

    function handleClick(): void {
        const customer:CustomerModel = {
            name,
            email
        };
        postCustomer(customer);
    }

    return (
        <>
            <h2>New Customer</h2>
            <div>
                <div className="mb-3">
                    <label className="form-label">Nume</label>
                    <input type="text" className="form-control" placeholder="Nume" onChange={ev => setName(ev.target.value)} />
                </div>
                <div className="mb-3">
                    <label className="form-label">Email</label>
                    <input type="text" className="form-control" placeholder="Email" onChange={ev => setEmail(ev.target.value)}/>
                </div>
                
                <a href="#" className="btn btn-primary" onClick={() =>{ handleClick();  }}>Save</a>
            </div>
        </>);
}
export default NewCustomer;


