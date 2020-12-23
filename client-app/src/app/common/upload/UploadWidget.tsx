import React, { useCallback, useContext } from "react";
import { useDropzone } from "react-dropzone";
import { Icon, Header } from "semantic-ui-react";
import { IFile } from "../../models/commonModels/files";
import { RootStoreContext } from "../../stores/rootStore";

interface IProps {
  setFiles: (files: IFile[]) => void;
}

const dropzoneStyles = {
  border: "dashed 3px",
  borderColor: "#eee",
  borderRadius: "5px",
  paddingTop: "5px",
  textAlign: "center" as "center",
  height: "120px",
};

const dropzoneActive = {
  borderColor: "green",
};

const UploadWidget: React.FC<IProps> = ({ setFiles }) => {
  const rootStore = useContext(RootStoreContext);
  const { setContractFile } = rootStore.employeeStore;

  const onDrop = useCallback(
    (acceptedFiles) => {
      const file = acceptedFiles.map((file: object) =>
        Object.assign(file, { preview: URL.createObjectURL(file) })
      );

      setContractFile(acceptedFiles);

      setFiles(file);
    },
    [setFiles]
  );
  const {
    getRootProps,
    getInputProps,
    isDragActive,
    acceptedFiles,
  } = useDropzone({ onDrop, accept:'.pdf, .docx' });

  return (
    <div
      {...getRootProps( )}
      style={
        isDragActive ? { ...dropzoneStyles, ...dropzoneActive } : dropzoneStyles
      }
    >
      <input  {...getInputProps()} />
      <Icon name="cloud upload" size="huge" />
      <Header content="Drop a file" />
    </div>
  );
};

export default UploadWidget;
