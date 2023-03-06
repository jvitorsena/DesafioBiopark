import * as React from 'react';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { TodosAlugueis, ITodosAlugueis, EditarAluguel } from '../../Config/alugueis';
import { TodosApartamentos, ITodosApartamentos } from '../../Config/apartamentos';
import { TodosLocatarios, ITodosLocatarios } from '../../Config/locatarios';
import { useEffect } from 'react';
import MenuItem from '@mui/material/MenuItem';

const style = {
    position: 'absolute' as 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    pt: 2,
    px: 4,
    pb: 3,
};

function ChildModal() {
    const [open, setOpen] = React.useState(false);

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };



    return (
        <React.Fragment>
            <Button onClick={handleOpen}>Open Child Modal</Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="child-modal-title"
                aria-describedby="child-modal-description"
            >
                <Box sx={{ ...style, width: 200 }}>
                    <h2 id="child-modal-title">Text in a child modal</h2>
                    <p id="child-modal-description">
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit.
                    </p>
                    <Button onClick={handleClose}>Close Child Modal</Button>
                </Box>
            </Modal>
        </React.Fragment>
    );
}

interface props {
    id: number;
    valorAluguelMen: number;
    locatarioId: number;
    apartamentoId: number;
}

export default function AlugueisEditModal(props: props) {
    const [open, setOpen] = React.useState(false);

    const [locatarios, setTodosLocatarios] = React.useState<Array<ITodosLocatarios>>([]);
    const [apartamentos, setTodosApartamentos] = React.useState<Array<ITodosApartamentos>>([]);

    const [apartamentoId, setApartamentoId] = React.useState<number>(props.apartamentoId);
    const [locatarioId, setLocatarioId] = React.useState<number>(props.locatarioId);
    const [valorAluguelMen, setValorAluguelMen] = React.useState<number>(props.valorAluguelMen);

    useEffect(() => {
        TodosApartamentos.then((json) => setTodosApartamentos(json)).catch((error) =>
            console.log(error)
        );
        TodosLocatarios.then((json) => setTodosLocatarios(json)).catch((error) =>
            console.log(error)
        );
        setApartamentoId(props.apartamentoId);
        setLocatarioId(props.locatarioId);
    }, []);


    function Editar() {
        console.log(valorAluguelMen, locatarioId, apartamentoId)
        EditarAluguel(valorAluguelMen, locatarioId, apartamentoId, props.id).then(() => window.location.reload()).catch((error) => console.log(error));
    }

    const handleOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div>
            <a className="mx-1" href="#" onClick={handleOpen}>
                Edit
            </a>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="parent-modal-title"
                aria-describedby="parent-modal-description"
            >
                <Box sx={{ ...style, width: 400 }}>
                    <div>
                        <TextField type='number' id="standard-basic" value={valorAluguelMen} label="Valor" variant="standard" onChange={(e) => setValorAluguelMen(Number(e.target.value))} />
                    </div>
                    <div className='mt-5'>
                        <TextField
                            id="outlined-select-currency"
                            select
                            label="Locatarios"
                            defaultValue="EUR"
                            helperText="Selecione o locatario"
                            onChange={(e) => setLocatarioId(Number(e.target.value))}
                            value={locatarioId}
                        >
                            {locatarios
                                .filter((value) => value.isActive === true)
                                .map((value) => (
                                    <MenuItem key={value.id} value={value.id}>
                                        {value.nome}
                                    </MenuItem>
                                ))}
                        </TextField>
                    </div>
                    <div className='mt-5'>
                        <TextField
                            id="outlined-select-currency"
                            select
                            label="Apartamentos"
                            defaultValue="EUR"
                            helperText="Selecione o apartamento"
                            onChange={(e) => setApartamentoId(Number(e.target.value))}
                            value={apartamentoId}
                        >
                            {apartamentos
                                .filter((value) => value.isActive === true && value.alugado === false)
                                .map((value) => (
                                    <MenuItem key={value.id} value={value.id}>
                                        {value.numero}
                                    </MenuItem>
                                ))}
                        </TextField>
                    </div>
                    <div className='mt-5'>
                        <Button onClick={() => Editar()}>Salvar</Button>
                        {/* <ChildModal /> */}
                    </div>
                </Box>
            </Modal>
        </div>
    );
}
