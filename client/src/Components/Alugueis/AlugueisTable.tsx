import {
    Button,
    createStyles,
    IconButton,
    makeStyles,
    Paper,
    Snackbar,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Theme,
    Typography,
    TablePagination,
} from "@mui/material";

import { ITodosAlugueis, TodosAlugueis, AlugueisCabecalho, ExcluirAluguel } from "../../Config/alugueis";
import { Delete, Edit } from "@mui/icons-material";
import React, { useEffect, useState } from "react";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import moment from "moment";
import { TrashIcon } from "../Icons";
import AlugueisEditModal from "./AlugueisEditModal";
import { ITodosEdificios } from "../../Config/edificios";

const darkTheme = createTheme({
    typography: {
        fontSize: 14,
    },
    components: {},
    palette: {
        mode: "dark",
    },
});

interface props {
    values: Array<ITodosAlugueis>;
    quantityValues: number;
    // setTodosApartamentos: React.Dispatch<React.SetStateAction<Array<ITodosApartamentos>>>
}

export default function AlugueisTable(props: props) {

    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(10);

    console.log(props.quantityValues)

    const handleChangePage = (event: unknown, newPage: number) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement>
    ) => {
        setRowsPerPage(+event.target.value);
        setPage(0);
    };

    function DelApartamento(id: number, apartamentoId: number) {
        ExcluirAluguel(id, apartamentoId).then(() => reload()).catch((error) => console.log(error));
    }

    const reload = async () => {
        await TodosAlugueis.then((json) => window.location.reload()).catch((error) =>
            console.log(error)
        );
    }

    console.log(props.values);

    return (
        <>
            <ThemeProvider theme={darkTheme}>
                {/* <a className='cursor-pointer' onClick={() => teste2()}>saodjaoid</a> */}
                <TableContainer>
                    <Table>
                        <TableRow>
                            {AlugueisCabecalho.map((value) => (
                                <TableCell>{value}</TableCell>
                            ))}
                        </TableRow>
                        <TableBody>
                            {props.values
                                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                .map((value) => (
                                    <TableRow>
                                        <TableCell component="th" scope="row">
                                            {value.id}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.valorAluguelMen}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.locatario}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.apartamento}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.createdAt).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {moment(value.updatedAt).format("DD/MM/YYYY")}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            {value.isActive ? "Ativo" : "Inativo"}
                                        </TableCell>
                                        <TableCell component="th" scope="row">
                                            <div className="flex flex-row items-center whitespace-nowrap text-right text-sm font-medium">
                                                <AlugueisEditModal
                                                    id={value.id}
                                                    valorAluguelMen={value.valorAluguelMen}
                                                    apartamentoId={value.apartamentoId}
                                                    locatarioId={value.locatarioId}
                                                />
                                                <a className="mx-1" href="#" onClick={() => DelApartamento(value.id, value.apartamentoId)}>
                                                    {TrashIcon}
                                                </a>
                                            </div>
                                        </TableCell>
                                    </TableRow>

                                ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </ThemeProvider>
            <TablePagination
                rowsPerPageOptions={[10, 25, 100]}
                component="div"
                count={props.quantityValues}
                rowsPerPage={rowsPerPage}
                page={page}
                onPageChange={handleChangePage}
                onRowsPerPageChange={handleChangeRowsPerPage}
            />
        </>
    );
}
