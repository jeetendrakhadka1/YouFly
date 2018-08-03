export class Transaction{
  constructor(
    public id: number,
    public ccNumber: number,
    public ccExp: number,    
    public userid: number,
    public flightid: number,
    public numOfBusTks: number,
    public numOfFCTks: number,
    public total: number
  ){}
}
