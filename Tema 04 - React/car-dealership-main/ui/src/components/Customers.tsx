import { useEffect, useState } from "react";
import { CustomerModel } from "../models/customer.model";
import { getCustomers } from "../common/api.service";
import { useNavigate } from "react-router-dom";
function Customers() {

    const navigate = useNavigate()

    const [customers, setCustomers] = useState<CustomerModel[]>([]);

    useEffect(() => {
        getCustomers().then(c => setCustomers(c));
    }, [])

    return (
        <>
            <p></p>
            <h2>Customers</h2>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">Nr</th>
                        <th scope="col">Nume</th>
                        <th scope="col">Email</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map(c =>
                        <tr>
                            <th scope="row">{customers.indexOf(c) + 1}</th>
                            <td>{c.name}</td>
                            <td>{c.email}</td>
                        </tr>

                    )}
                </tbody>
            </table>
            <button type="button" onClick={()=>  {navigate('/newcustomer')}} className="btn btn-primary">Add customer</button>




        </>


    );
}

export default Customers;