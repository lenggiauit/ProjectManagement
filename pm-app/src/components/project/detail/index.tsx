import React from "react";
import { useParams } from "react-router-dom";
import { ProjectDetail } from "../../../services/models/projectDetail";
import { useQuery } from "../../../utils/functions";

type Props = {
    detail?: ProjectDetail
}

const ProjectDetailComponent: React.FC<Props> = ({ detail }) => {
    return (<>
        {detail?.name}
    </>)
}

export default ProjectDetailComponent;