import { type } from "os";
import React from "react";
import { Project } from "../../services/models/project";


type Props = {
    project: Project
}

const ProjectItem: React.FC<Props> = ({ project }) => {

    return (<>
        <div className="col-6 col-lg-3">
            <a className="card shadow-1 hover-shadow-6" href="#" data-toggle="modal"  >

                <div className="card-body project-container team-type ">
                    <span className="project-type-tag po">PO</span>
                    <h6 className="mb-0">{project.name}</h6>
                    <div>
                        <small className="small-4 text-uppercase ls-2">{project.description}</small>
                    </div>
                </div>
            </a>
        </div>
    </>)
}

export default ProjectItem;