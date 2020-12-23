import React, { useState } from "react";
import Iframe from "react-iframe";
import { Link } from "react-router-dom";
import { Button, Header, Icon, Segment } from "semantic-ui-react";
import UploadWidget from "../../common/upload/UploadWidget";
import { IFile } from "../../models/commonModels/files";

const DocumentUpload = () => {
  const [files, setFiles] = useState<IFile[]>([]);
  return (
    <div>
      <Segment>
        <Header content="Document Upload" as="h3" />

        {/* <Button
          icon="trash"
          disabled={files.length > 0}
          style={{ background: "#fff" }}
        />

        {files.length > 0 ? (
          <Button
            as={Link}
            icon="external alternate"
            disabled={false}
            style={{ background: "#fff" }}
            to={files[0].preview}
            
          />
        ) : (
          <Button
            icon="external alternate"
            disabled={true}
            style={{ background: "#fff" }}
          />
        )} */}

        <UploadWidget setFiles={setFiles} />
      </Segment>

      {files.length !== 0 && (
        <Segment>
          <Iframe
            url={files[0].preview}
            width="100%"
            height="380px"
            position="relative"
          />
        </Segment>
      )}
    </div>
  );
};

export default DocumentUpload;
