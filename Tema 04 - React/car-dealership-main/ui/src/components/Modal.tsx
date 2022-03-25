import { CustomerModel } from "../models/customer.model";


interface TProps{
    customers: CustomerModel[];
}

function Modal(props: TProps) {

    const { customers } = props;

    return (
        <>
            <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                Buy
            </button>

            <div className="modal fade" id="exampleModal" tabIndex={-1} aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="exampleModalLabel">New order</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <div className="mb-3">
                                <label className="form-label">Nume</label>
                                <input type="text" className="form-control" placeholder="Nume" onChange={ev => {//setName(ev.target.value)
                                }} />
                            </div>
                            <div className="mb-3">
                                <label className="form-label">Email</label>
                                <input type="text" className="form-control" placeholder="Email" onChange={ev => {//setEmail(ev.target.value)}
                                }} />
                            </div>
                            <div className="input-group mb-3">
                                <select className="form-select" id="inputGroupSelect01">
                                    <option selected>Choose...</option>
                                    {customers.map(c=>
                                        <option value={customers.indexOf(c)}>{c.name}</option>
                                        )}
                                </select>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" className="btn btn-primary">Place order</button>
                        </div>
                    </div>
                </div>
            </div>

        </>

    );
}


export default Modal;