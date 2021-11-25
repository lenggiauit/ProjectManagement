import React, { ReactElement, useState } from 'react';
import { Redirect } from 'react-router-dom';
import Layout from '../../components/layout';
import { getLoggedUser } from '../../utils/functions';
import { Translation } from '../../components/translation';
import PageLoading from '../../components/pageLoading';
import { dictionaryList } from '../../locales';
import { useAppContext } from '../../contexts/appContext';
import { useUserUpdateProfileMutation } from '../../services/account';
import { Form, Field, Formik, FormikHelpers, ErrorMessage } from 'formik';
import * as Yup from "yup";

interface FormValues {
    username: string;
    password: string;
}
const Profile: React.FC = (): ReactElement => {
    const { locale, } = useAppContext();
    const currentUser = getLoggedUser();
    const [isEditMode, setIsEditMode] = useState<boolean>(false);
    let initialValues: FormValues = { username: '', password: '' };
    const [updateProfile, { isLoading, data, error }] = useUserUpdateProfileMutation();
    const handleEditMode = (value: boolean) => {
        setIsEditMode(value);
    }
    const validationSchema = () => {
        return Yup.object().shape({
            username: Yup.string().required(dictionaryList[locale]["RequiredField"]),
            password: Yup.string().required(dictionaryList[locale]["RequiredField"]),
        });
    }
    const handleOnSubmit = (values: FormValues, actions: FormikHelpers<FormValues>) => {


    }

    return (
        <>
            <Layout>
                {isLoading && <>
                    <PageLoading />
                </>}
                <section className="section overflow-hidden bg-gray">
                    <div className="container">
                        <header className="section-header">
                            <h2><Translation tid="Profile" /></h2>
                            <hr />
                        </header>
                        <div className="row gutters-sm">
                            <div className="col-md-4 mb-3">
                                <div className="card profile-card">
                                    <div className="card-body">
                                        <div className="d-flex flex-column align-items-center text-center">
                                            <img src={currentUser?.avatar} alt="Admin" className="rounded-circle" width="150" />
                                            <div className="mt-3">
                                                <h4>{currentUser && <> {currentUser.fullName} </>}</h4>
                                                <p className="text-success mb-1">{currentUser?.jobTitle}</p>
                                                <p className="text-muted font-size-sm">{currentUser && <> {currentUser.address} </>}</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div className="col-md-8">
                                <div className="card profile-card mb-3">
                                    <div className="card-body">
                                        <Formik initialValues={initialValues} onSubmit={handleOnSubmit} validationSchema={validationSchema} >
                                            <Form autoComplete="on">
                                                <div className="row">
                                                    <div className="col-sm-3">
                                                        <h6 className="mb-0"><Translation tid="FullName" /></h6>
                                                    </div>
                                                    <div className="col-sm-9">
                                                        {!isEditMode && <>
                                                            {currentUser?.fullName}
                                                        </>}
                                                        {isEditMode && <>
                                                            <div className="form-group-profile">
                                                                <Field type="text" className="form-control form-control-sm" name="fullName" />
                                                                <ErrorMessage
                                                                    name="fullName"
                                                                    component="div"
                                                                    className="alert alert-field alert-danger"
                                                                />
                                                            </div>
                                                        </>}
                                                    </div>
                                                </div>
                                                <hr />
                                                <div className="row">
                                                    <div className="col-sm-3">
                                                        <h6 className="mb-0"><Translation tid="JobTitle" /></h6>
                                                    </div>
                                                    <div className="col-sm-9">
                                                        {!isEditMode && <>
                                                            {currentUser?.jobTitle}
                                                        </>}
                                                        {isEditMode && <>
                                                            <div className="form-group-profile">
                                                                <Field type="text" className="form-control form-control-sm" name="jobTitle" />
                                                                <ErrorMessage
                                                                    name="jobTitle"
                                                                    component="div"
                                                                    className="alert alert-field alert-danger"
                                                                />
                                                            </div>
                                                        </>}
                                                    </div>
                                                </div>
                                                <hr />
                                                <div className="row">
                                                    <div className="col-sm-3">
                                                        <h6 className="mb-0"><Translation tid="Email" /></h6>
                                                    </div>
                                                    <div className="col-sm-9 ">
                                                        {!isEditMode && <>
                                                            {currentUser?.email}
                                                        </>}
                                                        {isEditMode && <>
                                                            <div className="form-group-profile">
                                                                <Field type="text" className="form-control form-control-sm" name="email" />
                                                                <ErrorMessage
                                                                    name="email"
                                                                    component="div"
                                                                    className="alert alert-field alert-danger"
                                                                />
                                                            </div>
                                                        </>}
                                                    </div>
                                                </div>
                                                <hr />
                                                <div className="row">
                                                    <div className="col-sm-3">
                                                        <h6 className="mb-0"><Translation tid="Phone" /></h6>
                                                    </div>
                                                    <div className="col-sm-9">
                                                        {!isEditMode && <>
                                                            {currentUser?.phone}
                                                        </>}
                                                        {isEditMode && <>
                                                            <div className="form-group-profile">
                                                                <Field type="phone" className="form-control form-control-sm" name="phone" />
                                                                <ErrorMessage
                                                                    name="phone"
                                                                    component="div"
                                                                    className="alert alert-field alert-danger"
                                                                />
                                                            </div>
                                                        </>}
                                                    </div>
                                                </div>

                                                <hr />
                                                <div className="row">
                                                    <div className="col-sm-3">
                                                        <h6 className="mb-0"><Translation tid="Address" /></h6>
                                                    </div>
                                                    <div className="col-sm-9">
                                                        {!isEditMode && <>
                                                            {currentUser?.address}
                                                        </>}
                                                        {isEditMode && <>
                                                            <div className="form-group-profile">
                                                                <Field type="text" className="form-control form-control-sm" name="address" />
                                                                <ErrorMessage
                                                                    name="address"
                                                                    component="div"
                                                                    className="alert alert-field alert-danger"
                                                                />
                                                            </div>
                                                        </>}
                                                    </div>
                                                </div>
                                                <hr />
                                            </Form>
                                        </Formik>
                                        <div className="row">
                                            <div className="col-sm-12 align-items-center text-center">
                                                {!isEditMode && <>
                                                    <button className="btn btn-round btn-primary" onClick={() => handleEditMode(true)} ><Translation tid="Edit" /></button>
                                                </>}
                                                {isEditMode && <>
                                                    <button type="submit" className="btn btn-round btn-primary"  ><Translation tid="Save" /></button>
                                                    &nbsp;
                                                    <button className="btn btn-round btn-secondary" onClick={() => handleEditMode(false)} ><Translation tid="Cancel" /></button>
                                                </>}

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </section>




            </Layout>

        </>
    );
}

export default Profile;