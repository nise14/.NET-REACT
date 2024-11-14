import React from 'react'
import Table from '../../components/table/Table'
import RatioList from '../../components/ratioList/RatioList'
import { testIncomeStatementData } from '../../components/table/TestData';

type Props = {}

const tableConfig = [
    {
        label: "Market Cap",
        render: (company: any) => company.marketCapTTM,
        subTitle: "Total value of all a company's shares of stock",
    }
];

function DesignPage({ }: Props) {
    return (
        <>
            <h1>
                Design guid- This is the design guide for Fin Shark. There are reusable
                components of the app with brief instructions on how to use them.
            </h1>
            <RatioList data={testIncomeStatementData} config={tableConfig}/>
            <Table data={testIncomeStatementData} config={tableConfig}/>
            <h3>
                Table - table takes in a configuration object and company data as
                params. Use the config to style your table.
            </h3>
        </>
    )
}

export default DesignPage