import { Product} from './products';
import {Store} from './stores';
import {Owner} from './owner';

export interface Sales {
    id: number
    purchase_value : number
    number_nf : string
    payment_type:number
    date_purchase:Date
    number_confirmation:number
    product : Product
    client : Owner
    store : Store
}