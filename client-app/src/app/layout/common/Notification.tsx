import React from "react";
import { Popup, Icon, Card, Image } from "semantic-ui-react";

interface IProps {}

const Notification: React.FC<IProps> = () => {
  return (
    <Popup
      trigger={<Icon size="large" name="bell" color="grey" />}
      position="bottom right"
      size="huge"
      pinned
    ></Popup>
  );
};
export default Notification;
