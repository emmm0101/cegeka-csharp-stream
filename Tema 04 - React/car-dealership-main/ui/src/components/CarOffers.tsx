import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getCars, getCustomers } from "../common/api.service";
import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";
import Car from "./Car";
import Modal from "./Modal";
import NewCar from "./NewCar";


//1. Props change
//2. State change

function CarOffers() {

    const navigate = useNavigate()

    const [cars, setCars] = useState<CarModel[]>([]);
    const [customers, setCustomers] = useState<CustomerModel[]>([]);
    const [flag] = useState(0)
    useEffect(() => {
        getCars().then(c => setCars(c));
    }, [])

    useEffect(() => {
        getCustomers().then(c => setCustomers(c));
    }, [])

    return (
        <div>
            <h2>All cars</h2>
            <button type="button" onClick={() => navigate('/newcar')} className="btn btn-primary">Add car</button>
            <div></div>
            <div style={{ display: 'flex', flexWrap: 'wrap' }}>
                {cars.map(c =>
                    <>
                        <form >
                            <Car car={c} />
                            <a className="btn btn-primary" onClick={() => navigate('/order', { state: { car: c } })}>Buy</a>
                        </form>
                    </>


                )}
            </div>
        </div>);
}

export default CarOffers;