import React from "react";
import { FieldRenderProps } from "react-final-form";
import { FormFieldProps, Form } from "semantic-ui-react";

interface IProps
  extends FieldRenderProps<string, HTMLElement>,
    FormFieldProps {}

const TimeInput: React.FC<IProps> = ({
  input,
  width,
  readOnly,
  type,
  placeholder,
  meta: { touched, error },
}) => {
  return (
    <Form.Field error={touched && !!error} type={type} width={width}>
      <input
        {...input}
        className={touched && error ? "timeError" : ""}
        placeholder={placeholder}
        readOnly={readOnly}
      />
    </Form.Field>
  );
};

export default TimeInput;
