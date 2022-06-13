import { Product} from './products';
import {Store} from './stores';
import {Client} from './client';

export interface Purchase {
    id: number
    purchase_value : number
    number_nf : string
    payment_type:number
    date_purchase:Date
    number_confirmation:number
    product : Product
    client : Client
}