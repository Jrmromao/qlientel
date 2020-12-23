import React, { useContext } from "react";
import { Form as FinalForm, Field } from "react-final-form";
import { Form, Button, Header } from "semantic-ui-react";
import { FORM_ERROR } from "final-form";
import {
  combineValidators,
  isRequired,
  matchesField,
  composeValidators,
} from "revalidate";
import TextInput from "../../common/form/TextInput";
import { RootStoreContext } from "../../stores/rootStore";
import ErrorMessage from "../../layout/common/ErrorMessage";
import { IRegisterFormValues } from "../../models/companyModels/company";

const validate = combineValidators({
  // email: createValidator(
  //   message => value => {
  //     if (value && !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(value)) {
  //       return message
  //     }
  //   },
  //   'Invalid email address'
  // ),

  email: isRequired("Email"),
  password: isRequired("Password"),
  repeatEmail: composeValidators(
    isRequired,
    matchesField("email", "Email")
  )("Repeat Email"),

  repeatPassword: composeValidators(
    isRequired,
    matchesField("password", "Password")
  )("Repeat Password"),
});
interface IProps {}

const RegisterForm: React.FC<IProps> = () => {
  const rootStore = useContext(RootStoreContext);
  const { register } = rootStore.userStore;
  return (
    <FinalForm
      onSubmit={(values: IRegisterFormValues) =>
        register(values).catch((error) => ({
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
          <Header as="h2" content="Register" color="teal" textAlign="center" />
          <Field
            name="companyName"
            component={TextInput}
            placeholder="Company Name"
          />
          <Field name="Username" component={TextInput} placeholder="Username" />

          <Field name="email" component={TextInput} placeholder="Email" />
          <Field
            name="repeatEmail"
            component={TextInput}
            placeholder="Repeat Email"
          />
          <Field
            name="password"
            component={TextInput}
            placeholder="Password"
            type="password"
          />
          <Field
            name="repeatPassword"
            component={TextInput}
            placeholder="Repeat Password"
            type="password"
          />
          {submitError && !dirtySinceLastSubmit && (
            <ErrorMessage error={submitError} text="Something went wrong" />
          )}
          <br />
          <Button
            disabled={(invalid && !dirtySinceLastSubmit) || pristine}
            loading={submitting}
            color="teal"
            content="Submit"
            fluid
            icon="pencil"
          />
        </Form>
      )}
    />
  );
};

export default RegisterForm;
