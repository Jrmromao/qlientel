import React from 'react'
import { List } from 'semantic-ui-react'
import { ICustomer } from '../../models/customerModels/customer'
interface IProps{
customer?: ICustomer
}
const CustomerDetails:React.FC<IProps> = ({customer}) => {
    return (
      <div  >

   
      <List>
        <List.Header>Email</List.Header>
        <List.Description>jill.kendu@hm.com</List.Description>
        <List.Header>Phone Number</List.Header>
        <List.Description>01 999 0000</List.Description>
        <List.Header>Date Joined</List.Header>
        <List.Description>January 11, 2014</List.Description>
        <List.Header>EPS</List.Header>
        <List.Description>9893 0993 093L</List.Description>
      </List>
 
   

   
      </div>
    )
}

export default CustomerDetails
