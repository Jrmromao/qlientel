import React from 'react'
import { Grid, Header, Segment } from 'semantic-ui-react'
import CustomerList from '../../components/customer/CustomerList'
import AddCustomer from '../../features/forms/AddCustomer'
import AdminLayout from '../../layout/admin/adminLayout'



const ManageCustomers:React.FC = () => {
    return (
      <AdminLayout>

        <Grid columns="2">
          <Grid.Column width="9">
            <Segment>
              <Header content="Customers List" />
              <CustomerList />
            </Segment>
          </Grid.Column>

          <Grid.Column width="7">
            <Segment>
              <Header content="Create Customers" />
              <AddCustomer />
            </Segment>
          </Grid.Column>
        </Grid>
      </AdminLayout>
    );
}

export default ManageCustomers
