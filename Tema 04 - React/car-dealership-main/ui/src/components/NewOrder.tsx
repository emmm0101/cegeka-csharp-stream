import { CustomerModel } from "../models/customer.model";
import { useNavigate } from "react-router-dom";
import { getCustomers, postOrder } from "../common/api.service";
import { useEffect, useState } from "react";
import { OrderModel } from "../models/order.model";


function NewOrder() {
    const navigate = useNavigate()

    const [customers, setCustomers] = useState<CustomerModel[]>([]);
    const [quantity, setQuantity] = useState(0)
    const [customerId, setCustomerId] = useState(0)
    const [carOfferId, setCarOfferId] = useState(0)

    useEffect(() => {
        getCustomers().then(c => setCustomers(c));
    }, [])

    function handleClick(): void {
        const order: OrderModel = {
            customerId,
            carOfferId,
            quantity
        };
        postOrder(order);
    }

    /*
        order{ 
            customerId, // get id from db based on email (unique)
            carOfferId, // get id from db based on model and make (unique) - to do: save data from the card that redirected to this page
            quantity // to do: check if is in stock
        }
    */

    return (
        <>
            <h2>New Order</h2>
            <div>
                <div className="input-group mb-3">
                    <label className="form-label">Customer</label>
                    <select className="form-select" id="inputGroupSelect01">
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

            </div>
        </>
    )
}

export default NewOrder