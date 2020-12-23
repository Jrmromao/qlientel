import React from "react";
import { Segment, Grid, Button, Header } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { AppMedia } from "../../constants/MediaScreen";
import { Link } from "react-router-dom";
import AdminLayout from "./adminLayout";
import { history } from "../../..";

const { MediaContextProvider } = AppMedia;

const ManageEmployeeLayout: React.FC = ({ children }) => {
  return (
    <MediaContextProvider>
      <AdminLayout>
        <Grid columns="2">
          <Grid.Column width="11">
            {children}

            {/* vou fazer desta pagina o layout e depois
           vou ter outra para mostrar todos os usuarios numa tabela  */}
          </Grid.Column>
          <Grid.Column width="5" className="manage-user-actions">
            <Segment>
              <Header as="h3" content="Action" />
              <Button
                icon="plus"
                color="green"
                labelPosition="left"
                as={Link}
                to="/add-user"
                fluid
                content="Add"
              />
         
            </Segment>
          </Grid.Column>
        </Grid>
      </AdminLayout>
    </MediaContextProvider>
  );
};

export default observer(ManageEmployeeLayout);
