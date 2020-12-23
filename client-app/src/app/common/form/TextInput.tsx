import React from "react";
import { FieldRenderProps } from "react-final-form";
import { FormFieldProps, Form, Label } from "semantic-ui-react";

interface IProps
  extends FieldRenderProps<string, HTMLElement>,
    FormFieldProps {}

const TextInput: React.FC<IProps> = ({
  input,
  width,
  readOnly,
  type,
  placeholder,
  label,
  pattern,
  meta: { touched, error },
}) => {
  return (
    <Form.Field error={touched && !!error} type={type} width={width}>
      <label>{label}</label>
      <input
        {...input}
        pattern={pattern}
        placeholder={placeholder}
        className={(readOnly ? "is-readOnly" : "") + " "}
        readOnly={readOnly}
      />
      {touched && error && (
        <Label basic color="red">
          {error}
        </Label>
      )}
    </Form.Field>
  );
};

export default TextInput;
