import React, { useContext, useEffect, useState } from "react";
import { Form as FinalForm, Field } from "react-final-form";
import {
  Form,
  Button,
  Header,
  Segment,
  Dropdown,
  DropdownProps,
} from "semantic-ui-react";
import { FORM_ERROR } from "final-form";
import {
  combineValidators,
  isRequired,
  composeValidators,
  matchesField,
} from "revalidate";
import TextInput from "../../common/form/TextInput";
import { RootStoreContext } from "../../stores/rootStore";
// import ErrorMessage from "../../../app/layout/ErrorMessage";

import DateInput from "../../common/form/DateInput";
import { observer } from "mobx-react-lite";
import { IAddEmployeeValues } from "../../models/employeeModels/employee";
import SelectInput from "../../common/form/SelectInput";
import ManageEmployee from "../../layout/admin/ManageEmployeeLayout";
import UploadWidget from "../../common/upload/UploadWidget";
import { history } from "../../..";

const validate = combineValidators({
  email: isRequired("Email"),
  role: isRequired("Role"),

  firstName: isRequired("First Name"),
  lastName: isRequired("Last Name"),
  office: isRequired("Office"),
  departmentId: isRequired("Department"),

  repeatEmail: composeValidators(
    isRequired,
    matchesField("email", "Email")
  )("Repeat Email"),
});

const validateViewOnly = combineValidators({});

interface IProps {}
const AddEmployee: React.FC<IProps> = (props: any) => {

  const rootStore = useContext(RootStoreContext);
  const {
    SubmitEmployeeDetails,
    userRoles,
  } = rootStore.employeeStore;
  const {
    departmentList,
  } = rootStore.officeStore;

  const {
    listJobTitles,
    jobTitleOptions,
    listSchedulePolicy,
    schedulePolicyOptions,
  } = rootStore.policyStore;
  const {
    company,
    GetCompanyDetail,
    GetNonBasicUsers,
    managersList,
  } = rootStore.adminStore;

  const [isDepartmentLoading, setIsDepartmentLoading] = useState(false);
  const [viewUserFlag, setViewUserFlag] = useState(false);
  const [header, setHeader] = useState("");
 
  const { match } = props;
  let { userId } = match.params;
  let { path } = match;

  useEffect(() => {
    if (path.includes("/update-user")) setHeader("Update User");

    if (path.includes("/view-user")) {
      setViewUserFlag(true);
      setHeader("View User");
    } else setHeader("Add User");
  }, [userId, setHeader, path]);
 
  return (
    <ManageEmployee>
      <Segment>
        <FinalForm
          onSubmit={(values: IAddEmployeeValues) =>
            SubmitEmployeeDetails(values).catch((error) => ({
              [FORM_ERROR]: error,
            }))
          }
          validate={viewUserFlag ? validateViewOnly : validate}
          render={({
            handleSubmit,
            submitting,
            submitError,
            invalid,
            pristine,
            dirtySinceLastSubmit,
          }) => (
            <Form onSubmit={handleSubmit} error>
              <Header as="h2" content={header} />

              <Header as="h3" content="User Details" />

              <Form.Group widths="equal">
                <Field
                  name="firstName"
                  component={TextInput}
                  placeholder="First Name"
                  readOnly={viewUserFlag}
                />
                <Field
                  name="lastName"
                  component={TextInput}
                  placeholder="Last Name"
                  readOnly={viewUserFlag}
                />
              </Form.Group>

              <Form.Group widths="equal">
                <Field
                  name="email"
                  type="email"
                  component={TextInput}
                  placeholder="Email Address"
                  readOnly={viewUserFlag}
                />

                <Field
                  name="repeatEmail"
                  component={TextInput}
                  type="email"
                  placeholder="Repeat Email Address"
                  readOnly={viewUserFlag}
                />
              </Form.Group>

              <Form.Group widths="equal">
                <Field
                  name="role"
                  component={SelectInput}
                  placeholder="Role"
                  options={userRoles}
                  readOnly={viewUserFlag}
                />

                <Field
                  className={
                    departmentList.length === 0 ? "is-readOnly-dropdown" : ""
                  }
                  name="departmentId"
                  component={SelectInput}
                  placeholder="Department"
                  disabled={departmentList.length === 0}
                  loading={isDepartmentLoading}
                  options={departmentList}
                  readOnly={viewUserFlag}
                />
              </Form.Group>

              <br />
              {viewUserFlag ? (
                <Button
                  onClick={() => history.goBack()}
                  primary
                  content="Return"
                  fluid
                  icon="arrow left"
                />
              ) : (
                <Button
                  disabled={(invalid && !dirtySinceLastSubmit) || pristine}
                  loading={submitting}
                  color="teal"
                  content="Submit"
                  fluid
                  icon="add"
                />
              )}
            </Form>
          )}
        />
      </Segment>
    </ManageEmployee>
  );
};

export default observer(AddEmployee);
