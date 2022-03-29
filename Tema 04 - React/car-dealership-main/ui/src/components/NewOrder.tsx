import { CustomerModel } from "../models/customer.model";
import { useNavigate, useLocation } from "react-router-dom";
import { getCustomers, postOrder } from "../common/api.service";
import { useEffect, useState } from "react";
import { OrderModel } from "../models/order.model";
import Car from "./Car";
import { CarModel } from "../models/car.model";


interface CustomizedState {
    car: CarModel
}

function NewOrder(props: any) {
    const navigate = useNavigate()

    const location = useLocation();
    const state = location.state as CustomizedState;
    const { car } = state;

    const [customers, setCustomers] = useState<CustomerModel[]>([]);
    const [quantity, setQuantity] = useState<number | null>(null)

    const [customerId, setCustomerId] = useState<number | null>(null)
    const carOfferId = car.id

    useEffect(() => {
        getCustomers().then(c => setCustomers(c));
    }, [])

    function checkInputsAreValid(): void {
        let buttonPost = document.getElementById('buttonPost') as HTMLButtonElement
        if (customerId != null && quantity != null && quantity > 0) {
            buttonPost.disabled = false;
        } else {
            buttonPost.disabled = true;
        }
    }

    useEffect(() => {
        checkInputsAreValid()
    }, [customerId, quantity])

    function handleClick(): void {
        const order: OrderModel = {
            customerId,
            carOfferId,
            quantity
        };
        console.log(order);
        postOrder(order);
        navigate('/caroffers')
    }

    function handleId(ev: any) {
        let idCustomer: number | undefined
        try {
            idCustomer = customers[parseInt(ev.target.value)].id
            if (typeof (idCustomer) != "undefined") {
                setCustomerId(idCustomer);
            }
        } catch {
            console.log('Choose a customer');
            setCustomerId(null);
        }
    }

    return (
        <>
            <h2>New Order for {car.make} {car.model}</h2>
            <div>
                <div>
                    <p>Customer</p>
                </div>
                <div className="input-group mb-3">
                    <select onChange={ev => handleId(ev)} className="form-select" id="inputGroupSelect01" required>
                        <option selected>Choose...</option>
                        {customers.map(c =>
                            <option value={customers.indexOf(c)}>{c.name}</option>
                        )}
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">Quantity</label>
                    <input type="text" className="form-control" placeholder="Quantity" onChange={ev => { setQuantity(Number(ev.target.value)) }} />
                </div>
                <button id="buttonPost" className="btn btn-primary"  onClick={ () =>{ handleClick();}} >Place order</button>

            </div>
        </>
    )
}

export default NewOrder