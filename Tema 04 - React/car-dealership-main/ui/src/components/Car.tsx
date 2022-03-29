import { CarModel } from "../models/car.model";
import Modal from "./Modal";
import { useNavigate, useLocation, Link } from "react-router-dom";
interface TProps{
    car: CarModel;
}

function Car(props: TProps){
    const navigate = useNavigate()
    const { car } = props;
   
    const discountPrice = car.unitPrice * (1-car.discountPercentage);
    const hasDiscount = car.discountPercentage > 0;

    const formatedPrice = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'EUR' }).format(car.unitPrice);
    const formatedDiscountPrice = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'EUR' }).format(discountPrice);
    const discount = '-' +(car.discountPercentage * 100) + '%';


    return (
        <div className="card" style={{width: '18rem', margin:20, position:'relative'}}>
            {hasDiscount && <span className="badge rounded-pill bg-danger" style={{width:50,position:'absolute'}}>{discount}</span> }
            <div style={{height:'12rem'}}>
                <img src={props.car.image} className="card-img-top" alt="..." />
            </div>
            <div className="card-body">
                <h5 className="card-title">{props.car.make}</h5>
                <p className="card-text">{props.car.model}</p>
                {
                    hasDiscount ? 
                    <>
                        <span className="card-text text-decoration-line-through">{formatedPrice}</span>
                        <p className="card-text" style={{color:'red', fontWeight:'bold'}}>{formatedDiscountPrice}</p>
                    </> :
                    <>
                        <span className="card-text">&nbsp;</span>
                        <p className="card-text" style={{color:'red', fontWeight:'bold'}}>{formatedDiscountPrice}</p>
                    </>
                }
                {/* 
                V1:
                <button className="btn btn-primary">
                    <Link style={{color:'white', textDecoration: 'none' }}  to="/order" state={{car:car}}>Buy</Link>
                </button> */
                }
                {/* 
                V2:
                <button className="btn btn-primary" onClick={()=>navigate('/order',  { state: { car: car } })}>Buy</button> */
                }
                {/* <a className="btn btn-primary" onClick={()=>navigate('/order',  { state: { car: car } })}>Buy</a> */}
            </div>

        </div>
    )
}

export default Car;