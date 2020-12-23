import React from "react";
import { Image } from "semantic-ui-react";
import { observer } from "mobx-react-lite";

interface IProps {
  size: any;
  src: any;
  children: any;
}

const ProfilePhotoText: React.FC<IProps> = ({ src, size, children }) => {
  const style: any = {
    alignSelf: "center",
    paddingLeft: "40px",
  };
  const imageStyle: any = {
    marginLeft: 35,
  
  };
  return (
    <div style={{ display: "inline-flex" }}>
      <Image
        style={imageStyle}
        verticalAlign="middle"
        src={src}
        size={size}
        circular
      />
      <div style={style}>{children}</div>
    </div>
  );
};

export default observer(ProfilePhotoText);

