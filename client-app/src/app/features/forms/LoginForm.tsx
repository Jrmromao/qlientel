import React, { useContext } from "react";
import { Form as FinalForm, Field } from "react-final-form";
import { Form, Button, Header } from "semantic-ui-react";
import { FORM_ERROR } from "final-form";
import { combineValidators, isRequired } from "revalidate";
import TextInput from "../../common/form/TextInput";
import { IUserFormValues } from "../../models/usersModels/user";
import { RootStoreContext } from "../../stores/rootStore";
import { Link } from "react-router-dom";
import ErrorMessage from "../../layout/common/ErrorMessage";

const validate = combineValidators({
  email: isRequired("Email"),
  password: isRequired("Password"),
});

const LoginForm = () => {
  const rootStore = useContext(RootStoreContext);
  const { Login } = rootStore.userStore;
  return (
    <FinalForm
      onSubmit={(values: IUserFormValues) =>
        Login(values).catch((error) => ({
          [FORM_ERROR]: error,
        }))
      }
      validate={validate}
      render={({
        handleSubmit,
        submitting,
        submitError,
        invalid,
        pristine,
        dirtySinceLastSubmit,
      }) => (
        <Form onSubmit={handleSubmit} error>
          <Header as="h2" content="Login" color="teal" textAlign="center" />
          <Field
            name="email"
            component={TextInput}
            placeholder="Email"
           
          />
          <Field
            name="password"
            component={TextInput}
            placeholder="Password"
            type="password"
            
          />
          {submitError && !dirtySinceLastSubmit && (
            <ErrorMessage
              error={submitError}
              text="Password ou Email Incorrect"
            />
          )}
          <br />
          <Button
            disabled={(invalid && !dirtySinceLastSubmit) || pristine}
            loading={submitting}
            color="teal"
            content="Login"
            fluid
            icon="sign in"
          />
          <Link to="#">Recover Password</Link>
        </Form>
      )}
    />
  );
};

export default LoginForm;
