import React, { useEffect, useState } from 'react';
import { MDBCard, MDBCardBody, MDBIcon, MDBBreadcrumb, MDBBreadcrumbItem, MDBFormInline, MDBBtn } from 'mdbreact';
import { useLocation } from 'react-router-dom';
import routes from '../../../config/routes';

const BreadcrumSection = (props) => {
  const loc = useLocation();
  const [item, setItem] = useState({
    parent: '',
    child: ''
  });
  const openModal = () => {
    props.openModal();
  }
  const fillBreadCrumb = () => {
    console.log(routes)
    const cr = routes.filter(i => loc.pathname.includes(i.path))[0];
    if(cr.child && cr.child.length > 0 ){
      const it = cr.child.filter(i => i.path === loc.pathname)[0];
      setItem(
        {
          ...item,
          parent: cr.perName,
          child: it.perName
        }
      )
    }
    else{
      setItem({
        ...item,
        parent: cr.perName
      }
      )
    }
  }
  useEffect(() => {
    fillBreadCrumb()
  }, []);
  return (
    <MDBCard className="mb-2">
        <MDBCardBody id="breadcrumb" className="d-flex align-items-center justify-content-between">
            <MDBBreadcrumb>
              
             <MDBBreadcrumbItem>{item !== undefined ? item.parent : ''}</MDBBreadcrumbItem>
             <MDBBreadcrumbItem>{item !== undefined ? item.child : ''}</MDBBreadcrumbItem>

            </MDBBreadcrumb>
            <MDBFormInline className="md-form m-0">
                {/* <input className="form-control form-control-sm" type="search" placeholder="Type your query" aria-label="Search"/> */}
                <MDBBtn size="sm" color="primary" className="my-0" onClick={openModal}><MDBIcon icon="plus" />{props.title}</MDBBtn>
            </MDBFormInline>
        </MDBCardBody>
    </MDBCard>
  )
}

export default BreadcrumSection;

