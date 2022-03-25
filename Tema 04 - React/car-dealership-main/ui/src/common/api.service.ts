import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";
import { OrderModel } from "../models/order.model";

export function getCars(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}

export function getCustomers(): Promise<CustomerModel[]> {
    return fetch('https://localhost:7198/Customer')
        .then(r => r.json())
}

export function postCar(car: CarModel) {
    fetch('https://localhost:7198/CarOffer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
}

export function postCustomer(customer: CustomerModel) {
    fetch('https://localhost:7198/Customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
}

export function postOrder(order: OrderModel) {
    fetch('https://localhost:7198/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    })
}

// to do 
export function getCarId(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}

// to do
export function getCustomerId(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}



