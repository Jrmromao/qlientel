import React, { useContext, useEffect, useState } from "react";
import { Form as FinalForm, Field } from "react-final-form";
import { Form, Button, Header, Dropdown } from "semantic-ui-react";
import { FORM_ERROR } from "final-form";
import {
  combineValidators,
  isRequired,
  composeValidators,
  matchesField,
} from "revalidate";
import { observer } from "mobx-react-lite";
import SelectInput from "../../common/form/SelectInput";

import TextInput from "../../common/form/TextInput";
import { RootStoreContext } from "../../stores/rootStore";
import DateInput from "../../common/form/DateInput";
import UploadWidget from "../../common/upload/UploadWidget";
import { ICustomer } from "../../models/customerModels/customer";

const AddCustomer: React.FC = () => {
  const rootStore = useContext(RootStoreContext);
  const { addCustomer } = rootStore.customerStore;
  return (
    <div>
      <FinalForm
        onSubmit={(values: ICustomer) =>
          addCustomer(values).catch((error) => ({
            [FORM_ERROR]: error,
          }))
        }
        //  validate={validate}
        render={({
          handleSubmit,
          submitting,
          submitError,
          invalid,
          pristine,
          dirtySinceLastSubmit,
        }) => (
          <Form onSubmit={handleSubmit} error>
            <Form.Group widths="equal">
              <Field
                name="Customer Name"
                component={TextInput}
                placeholder="Customer Name"
              />
            </Form.Group>

            <Form.Group widths="equal">
              <Field
                name="email"
                type="email"
                component={TextInput}
                placeholder="Email Address"
              />

              <Field
                name="repeatEmail"
                component={TextInput}
                type="email"
                placeholder="Repeat Email Address"
              />
            </Form.Group>

            <Form.Group widths="equal">
              <Field
                name="salary"
                component={TextInput}
                placeholder="Phone Number"
              />
              <Field
                name="Point of Contact"
                component={TextInput}
                placeholder="Point of contact"
              />
            </Form.Group>

            <br />
            <Button
              disabled={(invalid && !dirtySinceLastSubmit) || pristine}
              loading={submitting}
              color="teal"
              content="Submit"
              fluid
              icon="add"
            />
          </Form>
        )}
      />
    </div>
  );
};

export default observer(AddCustomer);
