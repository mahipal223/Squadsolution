import React from 'react'

const Footer = () => {
  return (

      <div className="container" >
        <footer className="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top">
          <div className="col-md-4 d-flex align-items-center">
            <a href="/" className="mb-3 me-2 mb-md-0 text-muted text-decoration-none lh-1">
              <svg className="bi" width="30" height="24"></svg>
            </a>
            <span className="mb-3 mb-md-0 text-muted">&copy;2022 Designed By Mahipal</span>
          </div>

          <ul className="nav col-md-4 justify-content-end list-unstyled d-flex">
           
          </ul>
        </footer>
      </div>

  )
}

export default Footer