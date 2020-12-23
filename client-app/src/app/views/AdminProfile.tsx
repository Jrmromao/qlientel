import React from "react";
import { Grid, Header, Segment } from "semantic-ui-react";
import CustomerList from "../components/customer/CustomerList";
import GlobalStorageUsageChart from "../components/dashnoard/GlobalStorageUsageChart";
import RecentActivity from "../components/dashnoard/RecentActivity";
import StorageUsageByCustomerChart from "../components/dashnoard/StorageUsageByCustomerChart";
import { AppMedia } from "../constants/MediaScreen";
import AdminLayout from "../layout/admin/adminLayout";

interface IProps {}

const { MediaContextProvider } = AppMedia;
const AdminProfile: React.FC<IProps> = () => {
  return (
    <MediaContextProvider>
      <AdminLayout>
        <Grid columns="2">
          <Grid.Column width="8">
            <GlobalStorageUsageChart />
          </Grid.Column>
          <Grid.Column width="8">
            <StorageUsageByCustomerChart />
          </Grid.Column>
        </Grid>

        <Grid>
          <Grid.Column width="10">
            <Segment color='blue'>
              <Header content="Recent Customer" />
              <br />
              <CustomerList />
            </Segment>
          </Grid.Column>
          <Grid.Column width="6">
            <RecentActivity />
          </Grid.Column>
        </Grid>
      </AdminLayout>
    </MediaContextProvider>
  );
};

export default AdminProfile;
