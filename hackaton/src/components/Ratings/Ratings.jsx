import React from 'react';

const Ratings = ({data}) => {
  return (
    <>
    <div className="card" style={{width: "18rem", boxShadow: "5px 5px 10px 5px rgba(0, 0, 0, 0.1)", display: 'inline-flex', marginTop: "3%", marginRight: "7%"}}>
        <div className="card-body">
            <h5 className="card-title">{data.name}</h5>
            <hr />
            {data.ratings.map((data1, index) => ( <>
                                                    <label> Mark: {data1.rating}</label>
                                                    <p className="card-text"> Comment: {data1.comment}</p>
                                                    <hr />
                                                    </>))}
            
        </div>
    </div>
    </>
  )
}

export default Ratings
