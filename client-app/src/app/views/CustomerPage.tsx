import React from "react";
import {  Grid,  Segment } from "semantic-ui-react";
import AdminLayout from "../layout/admin/adminLayout";

import CustomerDetails from "../components/customer/CustomerDetails";
import MapsContainer from "../components/MapsContainer";

import CustomerDocList from "../components/customer/CustomerDocList";
import DocumentUpload from "../components/customer/DocumentUpload";

const CustomerPage = () => {
  return (
    <AdminLayout>
      <div className="customer-header-section">
        <h1>H & M</h1>
      </div>
      <Segment className="customer-details-container">
        <Grid>
          <Grid.Column width="8">  
            <CustomerDetails />    
          </Grid.Column>
   
          <Grid.Column width="8"> 
            <MapsContainer />
          </Grid.Column>
        </Grid>
      </Segment>

      <Grid>
        <Grid.Column width="8">
          <CustomerDocList />
        </Grid.Column>
        <Grid.Column width="8">
 

 
 

          <DocumentUpload />
        </Grid.Column>
      </Grid>
    </AdminLayout>
  );
};

export default CustomerPage;
