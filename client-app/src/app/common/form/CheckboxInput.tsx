import React, { useContext } from "react";
import { FieldRenderProps } from "react-final-form";
import { FormFieldProps, Form, Label, Checkbox } from "semantic-ui-react";
import { RootStoreContext } from "../../stores/rootStore";
import { observer } from "mobx-react-lite";

interface IProps extends FieldRenderProps<any, HTMLElement>, FormFieldProps {}


const CheckboxInput: React.FC<IProps> = ({
  input,
  width,
  type,
  name,
  qNum,
  checked,
  label,
  onChange,
  meta: { touched, error },
}) => {
  
  return (
    <Form.Field error={touched && !!error} type={type} width={width} qNum={qNum}>
      <Form.Group widths={1}>
                    <Form.Field>
                    <Checkbox
                        radio
                        label={label}
                        name={name}
                        onChange={onChange}
                        checked={checked}
                      />
                    </Form.Field>
                  </Form.Group>

      {touched && error && (
        <Label basic color="red">
          {error}
        </Label>
      )}
    </Form.Field>
  );
};
export default observer(CheckboxInput)
