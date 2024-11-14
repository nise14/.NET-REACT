import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../../api';
import SideBar from '../../components/sidebar/SideBar';
import CompanyDashboard from '../../components/companydashboard/CompanyDashboard';
import Tile from '../../components/tile/Tile';
import Spinner from '../../components/spinner/Spinner';
import CompFinder from '../../components/compFinder/CompFinder';
import TenKFinder from '../../components/tenKFinder/TenKFinder';

interface Props { }

function CompanyPage(props: Props) {
  let { ticker } = useParams();
  const [company, setCompany] = useState<CompanyProfile>();

  useEffect(() => {

    const getProfileInit = async () => {
      const result = await getCompanyProfile(ticker!);
      setCompany(result?.data[0]);
    }

    getProfileInit();
  }, []);

  return (
    <>
      {company ? (
        <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
          <SideBar />
          <CompanyDashboard ticker={ticker!}>
            <Tile title='Company Name' subTitle={company.companyName} />
            <Tile title='Price' subTitle={"$"+company.price.toString()} />
            <Tile title='DCF' subTitle={"$"+company.dcf.toString()}/>
            <Tile title='Sector' subTitle={company.sector} />
            <CompFinder ticker={company.symbol} />
            <TenKFinder ticker={company.symbol}/>

            <p className='bg-white shadow rounded text-medium text-gray-900 p-3 mt-1 m-4'>
              {
                company.description
              }
            </p>
          </CompanyDashboard>
        </div>
      ) : (
        <Spinner/>
      )}
    </>
  )
}

export default CompanyPage