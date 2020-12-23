import React, { Fragment, useContext, useEffect } from "react";
import "../../styles/App.css";
import "../../styles/dashboard.css";
import "../../styles/protocols.css";
import "../../styles/NavMenu.css";
import "../../styles/profile.css";
import "../../styles/timeInput.css";
import "../../styles/customer.css";
import "../../styles/manageUser.css";

import {
  BrowserRouter as Router,
  Route,
  Switch,
  withRouter,
} from "react-router-dom";
import LoadingSpinner from "./LoadingSpinner";
import { observer } from "mobx-react-lite";
import { RootStoreContext } from "../../stores/rootStore";
import ModalContainer from "../../common/modals/ModalContainer";
import home from "../../views/home";
import AuthorizeRoute from "../../authentication/AuthorizeRoute";
import { NotFound } from "../../common/error/NotFound";
import EmployeeList from "../../components/EmployeeList";
import "mobx-react-lite/batchingForReactDom";
import UserProfile from "../../views/UserProfile";
import AdminProfile from "../../views/AdminProfile";

import ManageCustomers from "../../views/admin/ManageCustomers";
import CustomerPage from "../../views/CustomerPage";
import CustomerDetails from "../../components/customer/CustomerDetails";
import AddEmployee from "../../features/forms/AddEmployee";
import ManageUsers from "../../views/admin/ManageUsers";

const App: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const { token, setAppLoaded, appLoaded } = rootStore.commonStore;
  const { getUser } = rootStore.userStore;

  useEffect(() => {
    if (token) {
      getUser().finally(() => setAppLoaded());
    } else {
      setAppLoaded();
    }
  }, [getUser, setAppLoaded, token]);

  if (!appLoaded) return <LoadingSpinner content="Loading..." />;
  return (
    <Fragment>
      <ModalContainer />
      <Router>
        <Switch>
          <Route exact path="/" component={home} />
          <AuthorizeRoute path="/employee-directory" component={EmployeeList} />
          <AuthorizeRoute path="/employee-directory" component={EmployeeList} />
          <AuthorizeRoute path="/admin/dashboard" component={AdminProfile} />
          <AuthorizeRoute path="/user/dashboard" component={UserProfile} />
          <AuthorizeRoute path="/manager/dashboard" component={AdminProfile} />
          <AuthorizeRoute path="/manage-customer" component={ManageCustomers} />
          <AuthorizeRoute
            path="/customer/:customerId"
            component={CustomerPage}
          />
          <AuthorizeRoute path="/manage-user" component={ManageUsers} />
          <AuthorizeRoute
            path="/add-user"
            component={AddEmployee }
          />
          <AuthorizeRoute
            path="/update-user/:userId"
            component={AddEmployee}
          />
            <AuthorizeRoute
            path="/view-user/:userId"
            component={AddEmployee}
          />
          <Route path="/customer-registration" component={CustomerDetails} />
          <Route path="*" component={NotFound} />

          {/* <AuthorizeRoute path="/dashboard" component={manageCompanyDetails} />
          
          <AuthorizeRoute path="/employee-directory" component={EmployeeList} />
          <AuthorizeRoute exact path="/add-employee" component={AddEmployee} />
          <AuthorizeRoute exact path="/manage-policies" component={AddPolicy} />
          <AuthorizeRoute exact path="/company-directory" component={AddDepartment} />
          <AuthorizeRoute exact path="/add-policies" component={AddPolicy} />
          <AuthorizeRoute exact path="/update-policies" component={UpdatePolicy}/>
          <AuthorizeRoute exact path="/add-department" component={AddDepartment}/>
          <AuthorizeRoute exact path="/log-hours" component={LogHours} />
          <AuthorizeRoute exact path="/submit-leaves" component={AddLeaves} />
          <AuthorizeRoute exact path="/my-docs" component={MyDocs} />
          <AuthorizeRoute exact path="/my-finances" component={MyFiances} /> */}
        </Switch>
      </Router>
    </Fragment>
  );
};

export default withRouter(observer(App));
