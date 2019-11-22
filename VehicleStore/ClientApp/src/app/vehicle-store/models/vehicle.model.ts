import { Customer } from "./customer.model";

export interface Vehicle {
    id: number,
    vin: string,
    regNo: string,
    date: Date,
    isConnected: boolean,
    customerId: number,
    customer: Customer
}
